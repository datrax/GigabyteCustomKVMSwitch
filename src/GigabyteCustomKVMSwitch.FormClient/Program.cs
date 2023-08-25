namespace GigabyteCustomKVMSwitch_FormClient;

public static partial  class Program
{
    public static AppSettings appSettings = AppSettings.ReadFromFile();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();


        MainForm mainForm = new MainForm(appSettings);
        mainForm.Visible = false;

        _hookID = SetHook(_proc);

        Application.Run();

        UnhookWindowsHookEx(_hookID);
    }
}