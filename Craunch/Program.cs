using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Craunch
{
    static class Program
    {
        public static string EXE = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            EXE = System.Reflection.Assembly.GetExecutingAssembly().Location;

            if (FetchArg(args) == "-setup" || !File.Exists("craunch.dat"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SetupForm());

                return;
            }

            byte[] bytes = File.ReadAllBytes("craunch.dat");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LaunchForm(bytes));
        }

        static string FetchArg(string[] args)
        {
            if (args.Length >= 1)
                return args[0].ToLower();
            return string.Empty;
        }

        public static void Resave()
        {
            if (EXE == null)
                return;

            byte[] bytes = File.ReadAllBytes(EXE);
            try
            {
                File.WriteAllBytes("Craunch.exe", bytes);
            }
            catch
            {
            }
        }
    }
}
