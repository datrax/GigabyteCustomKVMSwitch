using GigabyteCustomKVMSwitch_Core.Monitors.M32Q;

namespace GigabyteCustomKVMSwitch_Core;

public class MonitorControllerFactory 
{
    public IMonitorController M32Q() => new M32QController();
}
