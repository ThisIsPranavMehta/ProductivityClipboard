using learningForms;
using System.Runtime.InteropServices;

namespace ProductivityClipboard
{
    internal static class Program
    {
        internal static Form1 MainForm;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            KeyLogger.Initialise();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MainForm = new Form1();
            TitleBarGui.UseImmersiveDarkMode(MainForm.Handle,true);
            Application.Run(MainForm);
        }
    }
}


