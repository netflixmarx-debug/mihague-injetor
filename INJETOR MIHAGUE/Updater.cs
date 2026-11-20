using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INJETOR_MIHAGUE
{
    internal static class Updater
    {
        // ── Versão atual embutida no código ─────────────────────────────────
        private const string CURRENT_VERSION = "1.0.3";


        // ── URL do version.json no seu repositório GitHub ───────────────────
        // Troque "SEU_USUARIO" e "SEU_REPOSITORIO" pelo seu user e repo do GitHub.
        // Para repo PRIVADO veja a nota no final deste arquivo.
        private const string VERSION_URL =
            "https://raw.githubusercontent.com/netflixmarx-debug/mihague-injetor/main/version.json";

        // ────────────────────────────────────────────────────────────────────
        // Checa se há update disponível e, se houver, baixa e reinicia.
        // Retorna true se aplicou update (processo vai fechar).
        // Retorna false se já está na versão mais recente ou se falhou.
        // ────────────────────────────────────────────────────────────────────
        public static bool CheckAndApply()
        {
            try
            {
                string json       = Fetch(VERSION_URL);
                string latest     = ParseField(json, "version");
                string downloadUrl = ParseField(json, "url");

                if (string.IsNullOrEmpty(latest) || latest == CURRENT_VERSION)
                    return false; // sem update

                DialogResult answer = MessageBox.Show(
                    "Nova versão disponível: " + latest + "\nAtualizar agora?",
                    "Atualização",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (answer != DialogResult.Yes)
                    return false;

                // Baixa o novo EXE
                byte[] newExe = FetchBytes(downloadUrl);
                if (newExe == null || newExe.Length == 0)
                {
                    MessageBox.Show("Falha ao baixar a atualização.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Salva o novo EXE em %TEMP%
                string tempNew = Path.Combine(Path.GetTempPath(), "MIHAGUEyt_update.exe");
                File.WriteAllBytes(tempNew, newExe);

                // Caminho do EXE atual
                string selfPath = Assembly.GetExecutingAssembly().Location;

                // Cria um .bat que:
                //   1. Espera o processo atual sair
                //   2. Substitui o EXE antigo pelo novo
                //   3. Abre o novo EXE
                //   4. Se apaga
                string batPath = Path.Combine(Path.GetTempPath(), "MIHAGUEyt_upd.bat");
                string bat =
                    "@echo off\r\n" +
                    ":wait\r\n" +
                    "tasklist /FI \"PID eq " + Process.GetCurrentProcess().Id + "\" 2>NUL | find /I \"MIHAGUEyt\" >NUL\r\n" +
                    "if not errorlevel 1 (\r\n" +
                    "    timeout /t 1 /nobreak >NUL\r\n" +
                    "    goto wait\r\n" +
                    ")\r\n" +
                    "move /y \"" + tempNew + "\" \"" + selfPath + "\"\r\n" +
                    "start \"\" \"" + selfPath + "\"\r\n" +
                    "del \"%~f0\"\r\n";

                File.WriteAllText(batPath, bat);

                // Lança o bat oculto e fecha o processo atual
                Process.Start(new ProcessStartInfo
                {
                    FileName        = batPath,
                    WindowStyle     = ProcessWindowStyle.Hidden,
                    CreateNoWindow  = true,
                    UseShellExecute = true
                });

                Application.Exit();
                return true;
            }
            catch
            {
                // Falha silenciosa — se o update não funcionar, o programa abre normalmente
                return false;
            }
        }

        // ── HTTP simples (síncrono via Task.Run para manter compatibilidade .NET 4.8) ──
        private static string Fetch(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(10);
                // Necessário para o GitHub não rejeitar a requisição
                client.DefaultRequestHeaders.Add("User-Agent", "MIHAGUEyt-Updater/1.0");
                Task<string> task = client.GetStringAsync(url);
                task.Wait();
                return task.Result;
            }
        }

        private static byte[] FetchBytes(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(60);
                client.DefaultRequestHeaders.Add("User-Agent", "MIHAGUEyt-Updater/1.0");
                Task<byte[]> task = client.GetByteArrayAsync(url);
                task.Wait();
                return task.Result;
            }
        }

        // ── Parser JSON mínimo (sem dependência de Newtonsoft) ──────────────
        // Extrai o valor de uma chave string no formato: "chave": "valor"
        private static string ParseField(string json, string key)
        {
            string search = "\"" + key + "\"";
            int idx = json.IndexOf(search, StringComparison.Ordinal);
            if (idx < 0) return null;

            idx = json.IndexOf(':', idx + search.Length);
            if (idx < 0) return null;

            idx = json.IndexOf('"', idx + 1);
            if (idx < 0) return null;

            int end = json.IndexOf('"', idx + 1);
            if (end < 0) return null;

            return json.Substring(idx + 1, end - idx - 1);
        }
    }
}

// ════════════════════════════════════════════════════════════════════════════
// COMO USAR — leia antes de publicar
// ════════════════════════════════════════════════════════════════════════════
//
// 1. Crie um repositório no GitHub (pode ser privado ou público).
//
// 2. Coloque na raiz do repositório um arquivo "version.json":
//
//      {
//        "version": "1.0.1",
//        "url": "https://github.com/SEU_USUARIO/SEU_REPOSITORIO/releases/download/v1.0.1/MIHAGUEyt Injetor.exe"
//      }
//
// 3. Crie uma Release no GitHub com a tag "v1.0.1" e faça upload do EXE compilado.
//
// 4. Substitua VERSION_URL acima pela URL raw do seu version.json.
//    Exemplo:
//    https://raw.githubusercontent.com/meuuser/meu-repo/main/version.json
//
// 5. Para publicar uma nova versão:
//    a. Mude CURRENT_VERSION aqui para "1.0.2" (ou o que for)
//    b. Compile o EXE
//    c. Crie nova Release no GitHub com a tag "v1.0.2" e sobe o novo EXE
//    d. Atualize o version.json no repositório com a nova versão e URL
//
// REPOSITÓRIO PRIVADO:
//    Raw files de repositórios privados precisam de token.
//    A forma mais simples: use o GitHub Releases com um link direto
//    de asset público, mesmo que o repositório seja privado.
//    Assets de Releases podem ser públicos independente da visibilidade do repo.
//    Para o version.json, use um Gist público ou um repo separado só pra isso.
// ════════════════════════════════════════════════════════════════════════════
