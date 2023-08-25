
using GigabyteCustomKVMSwitch_Core.Models.M32Q;

namespace GigabyteCustomKVMSwitch_Core;

public class MonitorControllerFactory 
{
    public IMonitorController M32Q() => new M32QController();
}
