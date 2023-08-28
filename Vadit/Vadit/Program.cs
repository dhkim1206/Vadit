using System.Data.SQLite;
using System.Drawing;
using System.Xml;

namespace Vadit
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            SplashScreen splash = new SplashScreen();

            splash.ShowDialog();

            Application.Run(new FormMain());
        }
    }
}