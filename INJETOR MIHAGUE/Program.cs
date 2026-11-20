using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace INJETOR_MIHAGUE
{
    internal static class Program
    {
        private static Assembly _guna = null;

        // Inicializador estático — roda antes de qualquer coisa, inclusive do JIT
        static Program()
        {
            // Extrai Guna para %TEMP%
            string gunaPath = Path.Combine(Path.GetTempPath(), "Guna.UI2.dll");

            using (Stream stream = Assembly.GetExecutingAssembly()
                                           .GetManifestResourceStream("INJETOR_MIHAGUE.Guna.UI2.dll"))
            {
                if (stream != null)
                {
                    byte[] bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    File.WriteAllBytes(gunaPath, bytes);
                    _guna = Assembly.LoadFrom(gunaPath);
                }
            }

            // Registra o resolver para o CLR encontrar quando precisar
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                if (args.Name.StartsWith("Guna.UI2", StringComparison.OrdinalIgnoreCase))
                    return _guna;
                return null;
            };
        }

        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao iniciar:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        static void Run()
        {
            Application.Run(new Form1());
        }
    }
}
