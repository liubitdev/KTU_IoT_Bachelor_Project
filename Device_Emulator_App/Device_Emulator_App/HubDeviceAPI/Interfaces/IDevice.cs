using System;
using System.Collections.Generic;
using System.Text;
using Device_Emulator_App.Models.Enums;

namespace Device_Emulator_App.HubDeviceAPI.Interfaces
{
    public interface IDevice
    {
        int Id { set; get; }
        string Name { set; get; }
        string Password { set; get; }
        EDeviceNetworkState State { set; get; }
        EDeviceType Type { set; get; }
        List<string> ActionList { get; set; }
    }
}
