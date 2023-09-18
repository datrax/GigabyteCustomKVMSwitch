using GigabyteCustomKVMSwitch_Core;
using Microsoft.Win32;

namespace GigabyteCustomKVMSwitch_FormClient;

public partial class MainForm : Form
{
    private const string UserRegistryPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
    private const string AutostartRegisterKeyName = "Gigabyte_KVM_client_autostart";
    private readonly AppSettings _appSettings;

    public MainForm(AppSettings appSettings)
    {
        _appSettings = appSettings;

        InitializeComponent();

        trayIcon.Visible = true;

        var rk = GetAutostartRegistryKey();
        autostartCheckbox.Checked = rk?.GetValue(AutostartRegisterKeyName) != null;

        appSettings = AppSettings.ReadFromFile();
        ctrlButtonCheckBox.Checked = appSettings.SpecialKeys.Contains(Keys.Control);
        altButtonCheckbox.Checked = appSettings.SpecialKeys.Contains(Keys.Alt);
        shiftButtonCheckBox.Checked = appSettings.SpecialKeys.Contains(Keys.Shift);

        additionalButtonInput.Text = appSettings.AdditionalKey.ToString();
        additionalButtonInput.Tag = Enum.Parse<Keys>(appSettings.AdditionalKey.ToString());
    }

    private void MainFormResized(object sender, EventArgs e)
    {
        if (this.WindowState == FormWindowState.Minimized)
        {
            Hide();
        }
    }

    private void TrayDoubleClick(object sender, MouseEventArgs e)
    {
        ToggleKvm();
    }

    private void ContextMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        if (e?.ClickedItem?.Text == "Settings")
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }
        if (e?.ClickedItem?.Text == "Exit")
        {
            this.Close();
            Application.Exit();
        }
    }

    private void MainFormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            Hide();
        }
    }

    private void ApplyButtonClicked(object sender, EventArgs e)
    {
        _appSettings.SpecialKeys.Clear();

        if (shiftButtonCheckBox.Checked)
        {
            _appSettings.SpecialKeys.Add(Keys.Shift);
        }


        if (ctrlButtonCheckBox.Checked)
        {
            _appSettings.SpecialKeys.Add(Keys.Control);
        }

        if (altButtonCheckbox.Checked)
        {
            _appSettings.SpecialKeys.Add(Keys.Alt);
        }

        _appSettings.AdditionalKey = (Keys)additionalButtonInput.Tag!;

        RegistryKey? rk = GetAutostartRegistryKey();
        if (autostartCheckbox.Checked)
            rk?.SetValue(AutostartRegisterKeyName, $"\"{Application.ExecutablePath}\"");
        else
            rk?.DeleteValue(AutostartRegisterKeyName, false);

        _appSettings.SaveToFile();

        this.Hide();
    }

    private void AdditionalButtonInputClicked(object sender, EventArgs e)
    {
        additionalButtonInput.Text = "Press your Key";

        additionalButtonInput.Select(0, 0);
    }

    private void AdditionalButtonInputKeyDown(object sender, KeyEventArgs e)
    {
        additionalButtonInput.Text = e.KeyCode.ToString();
        additionalButtonInput.Tag = e.KeyCode;

        additionalButtonInput.Select(0, 0);
    }


    private void ToggleKvm()
    {
        var factory = new MonitorControllerFactory();
        factory.M32Q().ToggleKvm();
    }

    private RegistryKey? GetAutostartRegistryKey()
    {
        return Registry.CurrentUser.OpenSubKey(UserRegistryPath, true);
    }
}