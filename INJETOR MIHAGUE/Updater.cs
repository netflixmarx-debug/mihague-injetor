using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace INJETOR_MIHAGUE
{
    internal static class Updater
    {
        private const string VERSION_URL =
            "https://raw.githubusercontent.com/netflixmarx-debug/mihague-injetor/main/version.json";

        public static void CheckAndApply(Action<string, Color> setStatus)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    var v = Assembly.GetExecutingAssembly().GetName().Version;
                    string current = v.Major + "." + v.Minor + "." + v.Build;

                    string json;
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers.Add("User-Agent", "MIHAGUEyt-Updater/1.0");
                        wc.Headers.Add("Cache-Control", "no-cache");
                        json = wc.DownloadString(VERSION_URL);
                    }

                    string latest      = ParseField(json, "version");
                    string downloadUrl = ParseField(json, "url");

                    if (string.IsNullOrEmpty(latest) || string.IsNullOrEmpty(downloadUrl))
                    {
                        setStatus("  ● Erro ao verificar versão", Color.FromArgb(255, 70, 70));
                        return;
                    }

                    if (new Version(latest) <= new Version(current))
                    {
                        setStatus("  ● Versão atualizada: v" + current, Color.FromArgb(0, 200, 80));
                        return;
                    }

                    Application.OpenForms[0].Invoke((Action)(() =>
                    {
                        MessageBox.Show(
                            "⚠️ ATUALIZAÇÃO OBRIGATÓRIA ⚠️\n\n" +
                            "Sua versão: v" + current + "\n" +
                            "Versão nova: v" + latest + "\n\n" +
                            "Versões antigas podem causar BANIMENTO.\n" +
                            "A atualização será feita automaticamente.",
                            "Atualização Obrigatória",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        setStatus("  ● Baixando atualização...", Color.FromArgb(255, 200, 0));

                        string selfPath = Assembly.GetExecutingAssembly().Location;
                        string tempNew  = selfPath + ".new.exe";
                        string batPath  = Path.Combine(Path.GetTempPath(), "mihague_upd.bat");

                        // HttpWebRequest segue redirecionamentos do GitHub Releases
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(downloadUrl);
                        req.UserAgent = "MIHAGUEyt-Updater/1.0";
                        req.AllowAutoRedirect = true;
                        req.Timeout = 60000;
                        using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
                        using (Stream src  = resp.GetResponseStream())
                        using (FileStream dst = File.Create(tempNew))
                            src.CopyTo(dst);

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
                        Process.Start(new ProcessStartInfo
                        {
                            FileName        = batPath,
                            WindowStyle     = ProcessWindowStyle.Hidden,
                            CreateNoWindow  = true,
                            UseShellExecute = true
                        });

                        Application.Exit();
                    }));
                }
                catch (Exception ex)
                {
                    setStatus("  ● Erro: " + ex.Message, Color.FromArgb(255, 70, 70));
                }
            });
        }

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
