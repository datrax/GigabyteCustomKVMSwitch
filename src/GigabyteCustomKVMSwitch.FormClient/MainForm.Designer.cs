namespace GigabyteCustomKVMSwitch_FormClient;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        trayIcon = new NotifyIcon(components);
        trayMenuStrip = new ContextMenuStrip(components);
        settingsMenuItem = new ToolStripMenuItem();
        exitMenuItem = new ToolStripMenuItem();
        autostartCheckbox = new CheckBox();
        shiftButtonCheckBox = new CheckBox();
        ctrlButtonCheckBox = new CheckBox();
        altButtonCheckbox = new CheckBox();
        applyButton = new Button();
        plusLabel = new Label();
        additionalButtonInput = new TextBox();
        shortcutLabel = new Label();
        trayMenuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // trayIcon
        // 
        trayIcon.ContextMenuStrip = trayMenuStrip;
        trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
        trayIcon.Text = "Gigabyte KVM Client";
        trayIcon.Visible = true;
        trayIcon.MouseDoubleClick += TrayDoubleClick;
        // 
        // trayMenuStrip
        // 
        trayMenuStrip.ImageScalingSize = new Size(20, 20);
        trayMenuStrip.Items.AddRange(new ToolStripItem[] { settingsMenuItem, exitMenuItem });
        trayMenuStrip.Name = "trayMenuStrip";
        trayMenuStrip.Size = new Size(132, 52);
        trayMenuStrip.ItemClicked += ContextMenuItemClicked;
        // 
        // settingsMenuItem
        // 
        settingsMenuItem.Name = "settingsMenuItem";
        settingsMenuItem.Size = new Size(131, 24);
        settingsMenuItem.Text = "Settings";
        // 
        // exitMenuItem
        // 
        exitMenuItem.Name = "exitMenuItem";
        exitMenuItem.Size = new Size(131, 24);
        exitMenuItem.Text = "Exit";
        // 
        // autostartCheckbox
        // 
        autostartCheckbox.AutoSize = true;
        autostartCheckbox.Location = new Point(327, 12);
        autostartCheckbox.Name = "autostartCheckbox";
        autostartCheckbox.Size = new Size(92, 24);
        autostartCheckbox.TabIndex = 1;
        autostartCheckbox.Text = "Autostart";
        autostartCheckbox.UseVisualStyleBackColor = true;
        // 
        // shiftButtonCheckBox
        // 
        shiftButtonCheckBox.AutoSize = true;
        shiftButtonCheckBox.Location = new Point(12, 32);
        shiftButtonCheckBox.Name = "shiftButtonCheckBox";
        shiftButtonCheckBox.Size = new Size(61, 24);
        shiftButtonCheckBox.TabIndex = 2;
        shiftButtonCheckBox.Text = "Shift";
        shiftButtonCheckBox.UseVisualStyleBackColor = true;
        // 
        // ctrlButtonCheckBox
        // 
        ctrlButtonCheckBox.AutoSize = true;
        ctrlButtonCheckBox.Location = new Point(12, 60);
        ctrlButtonCheckBox.Name = "ctrlButtonCheckBox";
        ctrlButtonCheckBox.Size = new Size(54, 24);
        ctrlButtonCheckBox.TabIndex = 3;
        ctrlButtonCheckBox.Text = "Ctrl";
        ctrlButtonCheckBox.UseVisualStyleBackColor = true;
        // 
        // altButtonCheckbox
        // 
        altButtonCheckbox.AutoSize = true;
        altButtonCheckbox.Location = new Point(12, 90);
        altButtonCheckbox.Name = "altButtonCheckbox";
        altButtonCheckbox.Size = new Size(50, 24);
        altButtonCheckbox.TabIndex = 4;
        altButtonCheckbox.Text = "Alt";
        altButtonCheckbox.UseVisualStyleBackColor = true;
        // 
        // applyButton
        // 
        applyButton.Location = new Point(165, 122);
        applyButton.Name = "applyButton";
        applyButton.Size = new Size(94, 29);
        applyButton.TabIndex = 5;
        applyButton.Text = "Apply";
        applyButton.UseVisualStyleBackColor = true;
        applyButton.Click += ApplyButtonClicked;
        // 
        // plusLabel
        // 
        plusLabel.AutoSize = true;
        plusLabel.Location = new Point(87, 61);
        plusLabel.Name = "plusLabel";
        plusLabel.Size = new Size(19, 20);
        plusLabel.TabIndex = 6;
        plusLabel.Text = "+";
        // 
        // additionalButtonInput
        // 
        additionalButtonInput.Location = new Point(134, 61);
        additionalButtonInput.Name = "additionalButtonInput";
        additionalButtonInput.ReadOnly = true;
        additionalButtonInput.Size = new Size(125, 27);
        additionalButtonInput.TabIndex = 7;
        additionalButtonInput.Text = "Back";
        additionalButtonInput.Click += AdditionalButtonInputClicked;
        additionalButtonInput.KeyDown += AdditionalButtonInputKeyDown;
        // 
        // shortcutLabel
        // 
        shortcutLabel.AutoSize = true;
        shortcutLabel.Location = new Point(9, 6);
        shortcutLabel.Name = "shortcutLabel";
        shortcutLabel.Size = new Size(97, 20);
        shortcutLabel.TabIndex = 8;
        shortcutLabel.Text = "KVM shortcut";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(431, 163);
        Controls.Add(shortcutLabel);
        Controls.Add(additionalButtonInput);
        Controls.Add(plusLabel);
        Controls.Add(applyButton);
        Controls.Add(altButtonCheckbox);
        Controls.Add(ctrlButtonCheckBox);
        Controls.Add(shiftButtonCheckBox);
        Controls.Add(autostartCheckbox);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "MainForm";
        Text = "Gigabyte KVM Client";
        FormClosing += MainFormClosing;
        Resize += MainFormResized;
        trayMenuStrip.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private NotifyIcon trayIcon;
    private ContextMenuStrip trayMenuStrip;
    private ToolStripMenuItem exitMenuItem;
    private ToolStripMenuItem settingsMenuItem;
    private CheckBox autostartCheckbox;
    private CheckBox shiftButtonCheckBox;
    private CheckBox ctrlButtonCheckBox;
    private CheckBox altButtonCheckbox;
    private Button applyButton;
    private Label plusLabel;
    private TextBox additionalButtonInput;
    private Label shortcutLabel;
}