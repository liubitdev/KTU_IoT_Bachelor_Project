using System;
using System.Collections.Generic;
using System.Text;
using Device_Emulator_App.Models.Enums;

namespace Device_Emulator_App.Models.Interfaces
{
    interface IDevice
    {
        int Id { set; get; }
        string Name { set; get; }
        DeviceState State { set; get; }

    }
}
