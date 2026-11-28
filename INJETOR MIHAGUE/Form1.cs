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
        // Logo PNG carregado do array embutido em LogoCirco.cs
        // ════════════════════════════════════════════════════════════════════
        private Image _logo = null;

        public Form1()
        {
            InitializeComponent();

            // Versão automática do AssemblyInfo
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = $"  v{ver.Major}.{ver.Minor}.{ver.Build}";

            // Ícone da janela
            using (Stream s = Assembly.GetExecutingAssembly()
                                      .GetManifestResourceStream("INJETOR_MIHAGUE.MIHAGUEyt_Corp.ico"))
            {
                if (s != null) this.Icon = new Icon(s);
            }

            // Carrega logo do array de bytes
            try
            {
                using (var ms = new System.IO.MemoryStream(LogoCirco.Data))
                    _logo = Image.FromStream(ms);
            }
            catch { _logo = null; }

            // Verifica atualização
            Updater.CheckAndApply((text, color) =>
            {
                if (this.InvokeRequired)
                    this.Invoke((Action)(() => SetStatus(text, color)));
                else
                    SetStatus(text, color);
            });
        }

        // ════════════════════════════════════════════════════════════════════
        // PAINT panelHeader — logo + "MIHAGUE" branco + "MODS" ciano
        // ════════════════════════════════════════════════════════════════════
        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode     = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.Clear(Color.FromArgb(10, 12, 16));

            int   logoSize = 44;
            int   logoX    = 14;
            int   logoY    = (panelHeader.Height - logoSize) / 2;

            // ── Logo ─────────────────────────────────────────────────────────
            if (_logo != null)
            {
                using (var gp = new GraphicsPath())
                {
                    gp.AddEllipse(logoX, logoY, logoSize, logoSize);
                    g.SetClip(gp);
                    g.DrawImage(_logo, logoX, logoY, logoSize, logoSize);
                    g.ResetClip();
                }
                using (var pen = new Pen(Color.FromArgb(0, 200, 200), 1.5f))
                    g.DrawEllipse(pen, logoX, logoY, logoSize, logoSize);
            }
            else
            {
                // Placeholder círculo ciano com tubarão
                using (var br = new SolidBrush(Color.FromArgb(0, 40, 40)))
                    g.FillEllipse(br, logoX, logoY, logoSize, logoSize);
                using (var pen = new Pen(Color.FromArgb(0, 200, 200), 1.5f))
                    g.DrawEllipse(pen, logoX, logoY, logoSize, logoSize);
                using (var f = new Font("Segoe UI", 20F, FontStyle.Bold))
                using (var br = new SolidBrush(Color.FromArgb(0, 200, 200)))
                {
                    var  sz = g.MeasureString("▲", f);
                    g.DrawString("▲", f, br,
                        logoX + (logoSize - sz.Width)  / 2f,
                        logoY + (logoSize - sz.Height) / 2f);
                }
            }

            // ── Texto "MIHAGUE MODS" ─────────────────────────────────────────
            int textX = logoX + logoSize + 12;

            using (var fTitle = new Font("Arial Black", 15F, FontStyle.Bold))
            {
                float textY = (panelHeader.Height - g.MeasureString("M", fTitle).Height) / 2f - 2f;

                // "MIHAGUE" em branco
                var szMH = g.MeasureString("MIHAGUE", fTitle);
                using (var br = new SolidBrush(Color.White))
                    g.DrawString("MIHAGUE", fTitle, br, textX, textY);

                // "MODS" em ciano, logo ao lado
                using (var br = new SolidBrush(Color.FromArgb(0, 200, 200)))
                    g.DrawString(" MODS", fTitle, br, textX + szMH.Width - 5f, textY);
            }

            // ── Subtítulo "Free Fire Internal" canto direito ─────────────────
            using (var fSub = new Font("Segoe UI", 7.5F))
            using (var br  = new SolidBrush(Color.FromArgb(70, 75, 90)))
            {
                const string sub = "Free Fire Internal  ";
                var  sz  = g.MeasureString(sub, fSub);
                g.DrawString(sub, fSub, br,
                    panelHeader.Width  - sz.Width,
                    panelHeader.Height - sz.Height - 4f);
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
        // PAINT Form — borda ciana fina
        // ════════════════════════════════════════════════════════════════════
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g    = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            using (var pen = new Pen(Color.FromArgb(60, 0, 200, 200), 1))
                g.DrawRectangle(pen, rect);
        }

        // ════════════════════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════════════════════
        private void SetStatus(string text, Color color)
        {
            status.Text      = "  " + text.TrimStart();
            status.ForeColor = color;
        }

        // ════════════════════════════════════════════════════════════════════
        // INJEÇÃO
        // ════════════════════════════════════════════════════════════════════
        private string ExtractEmbeddedDll()
        {
            string path = Path.Combine(Path.GetTempPath(), "MIHAGUE MODS.dll");
            using (Stream s = Assembly.GetExecutingAssembly()
                                      .GetManifestResourceStream("INJETOR_MIHAGUE.MIHAGUE MODS.dll"))
            {
                if (s == null) throw new Exception("DLL embutida não encontrada.");
                byte[] b = new byte[s.Length];
                s.Read(b, 0, b.Length);
                File.WriteAllBytes(path, b);
            }
            return path;
        }

        private bool InjectIntoProcess(string name, string dll)
        {
            var procs = Process.GetProcessesByName(name);
            if (procs.Length == 0) return false;

            IntPtr hProc = OpenProcess(0x1F0FFF, false, procs[0].Id);
            if (hProc == IntPtr.Zero)
            {
                MessageBox.Show("Falha ao abrir processo: " + name + "\nCódigo: " + Marshal.GetLastWin32Error(),
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            IntPtr loadLib = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (loadLib == IntPtr.Zero) { CloseHandle(hProc); return false; }

            IntPtr alloc = VirtualAllocEx(hProc, IntPtr.Zero, (IntPtr)(dll.Length + 1), MEM_COMMIT, PAGE_READWRITE);
            if (alloc == IntPtr.Zero) { CloseHandle(hProc); return false; }

            byte[] buf = Encoding.ASCII.GetBytes(dll + "\0");
            if (!WriteProcessMemory(hProc, alloc, buf, (uint)buf.Length, out _))
            { CloseHandle(hProc); return false; }

            IntPtr thread = CreateRemoteThread(hProc, IntPtr.Zero, IntPtr.Zero, loadLib, alloc, 0, IntPtr.Zero);
            if (thread == IntPtr.Zero) { CloseHandle(hProc); return false; }

            CloseHandle(hProc);
            return true;
        }

        private bool InjectDLL()
        {
            try
            {
                string dll = ExtractEmbeddedDll();

                if (InjectIntoProcess("MEmuHeadless", dll)) return true;
                if (InjectIntoProcess("MEmu",         dll)) return true;
                if (InjectIntoProcess("MEmuAndroid",  dll)) return true;
                if (InjectIntoProcess("HD-Player",    dll)) return true;
                if (InjectIntoProcess("Bluestacks",   dll)) return true;
                if (InjectIntoProcess("BstkSVC",      dll)) return true;

                MessageBox.Show(
                    "Nenhum emulador encontrado.\nAbra o MSI App Player ou BlueStacks e tente novamente.",
                    "Processo não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // BOTÕES
        // ════════════════════════════════════════════════════════════════════
        private void btnTabDiscord_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/HrQcJvNvuc");
        }

        private void btnTabYoutube_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/@mihagueyt");
        }

        // ════════════════════════════════════════════════════════════════════
        // TOGGLE — injeta e fecha ao sucesso
        // ════════════════════════════════════════════════════════════════════
        private void toggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (!toggle1.Checked) return;

            SetStatus("● Injetando...", Color.FromArgb(255, 200, 0));

            bool ok = InjectDLL();
            if (ok)
            {
                SetStatus("● Injeção concluída!", Color.FromArgb(0, 220, 80));
                var t = new Timer { Interval = 1000 };
                t.Tick += (cs, ce) => { t.Stop(); t.Dispose(); Application.Exit(); };
                t.Start();
            }
            else
            {
                SetStatus("● Falha na injeção.", Color.FromArgb(255, 70, 70));
                toggle1.Checked = false;
            }
        }
    }
}
