using System;
using System.IO;
using System.Windows.Forms;

namespace Neurospora
{
    static class Program
    {
        public const string tmpFolder = "~tmp";
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists(tmpFolder)) Directory.CreateDirectory(Program.tmpFolder);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
            if (Directory.Exists(tmpFolder)) Directory.Delete(tmpFolder, true);
        }
    }
}
