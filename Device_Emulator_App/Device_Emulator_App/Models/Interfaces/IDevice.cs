using System;
using System.Collections.Generic;
using System.Text;
using Device_Emulator_App.Models.Enums;

namespace Device_Emulator_App.Models.Interfaces
{
    public interface IDevice
    {
        int Id { set; get; }
        string Name { set; get; }
        EDeviceNetworkState State { set; get; }

    }
}
