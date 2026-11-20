using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace INJETOR_MIHAGUE
{
    public partial class Form1 : Form
    {
        // ════════════════════════════════════════════════════════════════════
        // PISCAR + 3D — paint do lblTitle com efeito overlay mesclado
        // ════════════════════════════════════════════════════════════════════
        private Timer _blinkTimer;
        private bool  _blinkRed = true;

        public Form1()
        {
            InitializeComponent();

            // Versão automática do AssemblyInfo
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = $"v{version.Major}.{version.Minor}.{version.Build}  ";

            // Carrega o ícone embutido no assembly
            using (Stream s = Assembly.GetExecutingAssembly()
                                      .GetManifestResourceStream("INJETOR_MIHAGUE.MIHAGUEyt_Corp.ico"))
            {
                if (s != null)
                    this.Icon = new Icon(s);
            }

            _blinkTimer          = new Timer();
            _blinkTimer.Interval = 500;
            _blinkTimer.Tick    += (s, e) =>
            {
                _blinkRed = !_blinkRed;
                lblTitle.Invalidate();
            };
            _blinkTimer.Start();

            // Verifica atualização em background
            System.Threading.Tasks.Task.Run(() => CheckForUpdate());
        }

        // ════════════════════════════════════════════════════════════════════
        // AUTO-UPDATE — consulta version.json no GitHub
        // ════════════════════════════════════════════════════════════════════
        private const string VERSION_URL = "https://raw.githubusercontent.com/netflixmarx-debug/mihague-injetor/main/version.json";

        private void CheckForUpdate()
        {
            try
            {
                var currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string currentStr  = $"{currentVersion.Major}.{currentVersion.Minor}.{currentVersion.Build}";

                using (System.Net.WebClient wc = new System.Net.WebClient())
                {
                    wc.Headers.Add("Cache-Control", "no-cache");
                    string json = wc.DownloadString(VERSION_URL);

                    string remoteVersion = ExtractJsonValue(json, "version");
                    string downloadUrl   = ExtractJsonValue(json, "url");

                    if (string.IsNullOrEmpty(remoteVersion) || string.IsNullOrEmpty(downloadUrl))
                    {
                        this.Invoke((Action)(() =>
                            SetStatus("  ● Erro ao ler version.json", Color.FromArgb(255, 70, 70))));
                        return;
                    }

                    if (IsNewerVersion(remoteVersion, currentStr))
                    {
                        this.Invoke((Action)(() =>
                        {
                            MessageBox.Show(
                                "⚠️ ATUALIZAÇÃO OBRIGATÓRIA ⚠️\n\n" +
                                "Sua versão está desatualizada: v" + currentStr + "\n" +
                                "Versão atual: v" + remoteVersion + "\n\n" +
                                "Você DEVE atualizar para continuar usando.\n" +
                                "Versões antigas podem causar BANIMENTO.",
                                "Atualização Obrigatória",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            DownloadAndUpdate(downloadUrl);
                        }));
                    }
                    else
                    {
                        this.Invoke((Action)(() =>
                            SetStatus("  ● Versão atualizada: v" + currentStr, Color.FromArgb(0, 200, 80))));
                    }
                }
            }
            catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                    SetStatus("  ● Sem conexão ou erro: " + ex.Message, Color.FromArgb(255, 70, 70))));
            }
        }

        private void DownloadAndUpdate(string url)
        {
            try
            {
                SetStatus("  ● Baixando atualização...", Color.FromArgb(255, 200, 0));

                string exePath  = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string tempPath = exePath + ".new.exe";
                string batPath  = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "mihague_update.bat");

                using (System.Net.WebClient wc = new System.Net.WebClient())
                    wc.DownloadFile(url, tempPath);

                string bat = "@echo off\r\n" +
                             "timeout /t 2 /nobreak >nul\r\n" +
                             "move /y \"" + tempPath + "\" \"" + exePath + "\"\r\n" +
                             "start \"\" \"" + exePath + "\"\r\n" +
                             "del \"%~f0\"\r\n";

                System.IO.File.WriteAllText(batPath, bat);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName       = batPath,
                    CreateNoWindow = true,
                    WindowStyle    = System.Diagnostics.ProcessWindowStyle.Hidden
                });

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ExtractJsonValue(string json, string key)
        {
            string search = "\"" + key + "\"";
            int idx = json.IndexOf(search);
            if (idx < 0) return null;
            int colon = json.IndexOf(':', idx);
            if (colon < 0) return null;
            int q1 = json.IndexOf('"', colon + 1);
            if (q1 < 0) return null;
            int q2 = json.IndexOf('"', q1 + 1);
            if (q2 < 0) return null;
            return json.Substring(q1 + 1, q2 - q1 - 1);
        }

        private bool IsNewerVersion(string remote, string current)
        {
            try { return new Version(remote) > new Version(current); }
            catch { return false; }
        }

        // ════════════════════════════════════════════════════════════════════
        // PAINT lblTitle — "BigZin Store" 3D mesclado vermelho/branco
        // ════════════════════════════════════════════════════════════════════
        private void lblTitle_Paint(object sender, PaintEventArgs e)
        {
            Label    lbl = (Label)sender;
            Graphics g   = e.Graphics;
            g.SmoothingMode     = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            // Fundo sólido — evita artefato de transparência
            g.Clear(Color.FromArgb(18, 18, 18));

            string text = "MIHAGUEyt";

            Color colorFront = _blinkRed ? Color.FromArgb(220, 30, 30) : Color.White;
            Color colorBack  = _blinkRed ? Color.White : Color.FromArgb(220, 30, 30);

            // Usa uma cópia da fonte — nunca dar Dispose na fonte do controle
            using (Font f = new Font(lbl.Font.FontFamily, lbl.Font.Size, lbl.Font.Style, GraphicsUnit.Point))
            {
                SizeF sz = g.MeasureString(text, f);
                float x  = (lbl.Width  - sz.Width)  / 2f;
                float y  = (lbl.Height - sz.Height) / 2f;

                // Sombra — 2px deslocado, cor secundária semitransparente
                using (Brush shadow = new SolidBrush(Color.FromArgb(160, colorBack)))
                    g.DrawString(text, f, shadow, x + 2f, y + 2f);

                // Intermediária — 1px deslocado
                using (Brush mid = new SolidBrush(Color.FromArgb(220, colorBack)))
                    g.DrawString(text, f, mid, x + 1f, y + 1f);

                // Frontal — posição original
                using (Brush front = new SolidBrush(colorFront))
                    g.DrawString(text, f, front, x, y);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // WIN32
        // ════════════════════════════════════════════════════════════════════
        private const uint MEM_COMMIT     = 0x1000;
        private const uint PAGE_READWRITE = 0x04;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr size, uint type, uint protect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr address, byte[] buffer, uint size, out IntPtr written);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr attributes,
            IntPtr stackSize, IntPtr startAddress, IntPtr parameter, uint flags, IntPtr threadId);

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hObject);

        // ════════════════════════════════════════════════════════════════════
        // PAINT — borda fina ao redor do form
        // ════════════════════════════════════════════════════════════════════
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            using (Pen pen = new Pen(Color.FromArgb(100, 60, 120, 180), 1))
                g.DrawRectangle(pen, rect);
        }

        // ════════════════════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════════════════════
        private void SetStatus(string text, Color color)
        {
            status.Text      = text;
            status.ForeColor = color;
        }

        // ════════════════════════════════════════════════════════════════════
        // INJEÇÃO — extrai DLL embutida e injeta
        // ════════════════════════════════════════════════════════════════════
        private string ExtractEmbeddedDll()
        {
            string tempDllPath = Path.Combine(Path.GetTempPath(), "MIHAGUEyt.dll");
            using (Stream stream = Assembly.GetExecutingAssembly()
                                           .GetManifestResourceStream("INJETOR_MIHAGUE.MIHAGUEyt.dll"))
            {
                if (stream == null)
                    throw new Exception("DLL embutida não encontrada no recurso.");
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                File.WriteAllBytes(tempDllPath, bytes);
            }
            return tempDllPath;
        }

        private bool InjectIntoProcess(string processName, string tempDllPath)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
                return false;

            Process target  = processes[0];
            IntPtr hProcess = OpenProcess(0x1F0FFF, false, target.Id);
            if (hProcess == IntPtr.Zero)
            {
                MessageBox.Show(
                    "Processo encontrado: " + processName + "\nFalha ao abrir. Código: " + Marshal.GetLastWin32Error(),
                    "Erro OpenProcess", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            IntPtr loadLibrary = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (loadLibrary == IntPtr.Zero) { CloseHandle(hProcess); return false; }

            IntPtr alloc = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)(tempDllPath.Length + 1), MEM_COMMIT, PAGE_READWRITE);
            if (alloc == IntPtr.Zero) { CloseHandle(hProcess); return false; }

            byte[] bytes = Encoding.ASCII.GetBytes(tempDllPath + "\0");
            if (!WriteProcessMemory(hProcess, alloc, bytes, (uint)bytes.Length, out _))
            { CloseHandle(hProcess); return false; }

            IntPtr thread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibrary, alloc, 0, IntPtr.Zero);
            if (thread == IntPtr.Zero) { CloseHandle(hProcess); return false; }

            CloseHandle(hProcess);
            return true;
        }

        // Tenta todas as variações de processo do MSI App Player e BlueStacks.
        private bool InjectDLL()
        {
            try
            {
                string tempDllPath = ExtractEmbeddedDll();

                // MSI App Player — variações por versão
                if (InjectIntoProcess("MEmuHeadless", tempDllPath)) return true;
                if (InjectIntoProcess("MEmu", tempDllPath))         return true;
                if (InjectIntoProcess("MEmuAndroid", tempDllPath))  return true;

                // BlueStacks — variações por versão
                if (InjectIntoProcess("HD-Player", tempDllPath))    return true;
                if (InjectIntoProcess("Bluestacks", tempDllPath))   return true;
                if (InjectIntoProcess("BstkSVC", tempDllPath))      return true;

                MessageBox.Show(
                    "Nenhum emulador encontrado.\nAbra o MSI App Player ou BlueStacks e tente novamente.",
                    "Processo não encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // BOTÕES — Discord e YouTube
        // ════════════════════════════════════════════════════════════════════
        private void btnTabDiscord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/HrQcJvNvuc");
        }

        private void btnTabYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/@mihagueyt");
        }

        // ════════════════════════════════════════════════════════════════════
        // TOGGLE 1 — Enable Painel → injeta e fecha ao sucesso
        // ════════════════════════════════════════════════════════════════════
        private void toggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (!toggle1.Checked) return;

            SetStatus("  ● Injetando...", Color.FromArgb(255, 200, 0));

            bool ok = InjectDLL();
            if (ok)
            {
                SetStatus("  ● Injeção concluída!", Color.FromArgb(0, 220, 80));

                // Aguarda 1 segundo e fecha
                Timer closeTimer = new Timer();
                closeTimer.Interval = 1000;
                closeTimer.Tick += (cs, ce) =>
                {
                    closeTimer.Stop();
                    closeTimer.Dispose();
                    Application.Exit();
                };
                closeTimer.Start();
            }
            else
            {
                SetStatus("  ● Falha na injeção.", Color.FromArgb(255, 70, 70));
                toggle1.Checked = false;
            }
        }
    }
}
