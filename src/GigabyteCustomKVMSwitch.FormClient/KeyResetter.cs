using System.Runtime.InteropServices;

public class KeyResetter
{
    [DllImport("user32.dll", SetLastError = true)]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);

    const int KEYEVENTF_KEYUP = 0x0002;

    public static void ResetKeys(IEnumerable<Keys> keys)
    {
        foreach (Keys key in keys)
        {
            keybd_event((byte)key, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
        }
    }
}