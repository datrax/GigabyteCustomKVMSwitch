namespace GigabyteCustomKVMSwitch_Core;

public interface IMonitorController
{
    MonitorModel Model { get; }

    bool ToggleKvm();
}
