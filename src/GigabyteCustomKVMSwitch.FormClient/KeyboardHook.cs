using GigabyteCustomKVMSwitch_Core;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GigabyteCustomKVMSwitch_FormClient;

public static partial class Program
{
    private const int WH_KEYBOARD_LL = 13;
    private static LowLevelKeyboardProc _proc = HookCallback;
    private static IntPtr _hookID = IntPtr.Zero;
    private static DateTime? TimeStamp = null;

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);


    private static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule!)
        {
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule!.ModuleName), 0);
        }
    }

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (TimeStamp.HasValue && (DateTime.UtcNow - TimeStamp.Value).TotalSeconds < 5) return 0;

        if (nCode >= 0)
        {
            Keys key = (Keys)Marshal.ReadInt32(lParam);

            if (key == appSettings.AdditionalKey)
            {
                if (wParam == 257 && Control.ModifierKeys == appSettings.ModifierKeys && key == appSettings.AdditionalKey)
                {
                    TimeStamp = DateTime.UtcNow;

                    while (Control.ModifierKeys != Keys.None)
                    {                       
                        Thread.Sleep(50);
                    }
                    
                    var factory = new MonitorControllerFactory();
                    factory.M32Q().ToggleKvm();
                }
            }
        }
        return 0;
    }
}