namespace PantawidPasada
{
    /// <summary>
    /// The main entry point class for the PantawidPasada application.
    /// Bootstraps the Windows Forms application and launches the login screen (Form1).
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Initializes application configuration (DPI, fonts, etc.) and starts the login form.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Apply high-DPI and default font settings before any UI is created.
            // See https://aka.ms/applicationconfiguration for customization options.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
