namespace GigabyteCustomKVMSwitch_Core.Exceptions;

internal class DeviceNotFoundException : ControllerException
{
    public DeviceNotFoundException(IMonitorController controller) : base(controller, "Device not found.")
    {
    }
}
