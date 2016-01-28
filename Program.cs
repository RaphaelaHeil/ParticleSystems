using System;
using System.Windows.Forms;

namespace ParticleSystems
{
    static class Program
    {
        /// <summary>
        /// The application's main entry point.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrame());
        }
    }
}