using System;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
