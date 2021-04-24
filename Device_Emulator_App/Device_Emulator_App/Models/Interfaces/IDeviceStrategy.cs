using System;
using System.Collections.Generic;
using System.Text;

namespace Device_Emulator_App.Models.Interfaces
{
    public interface IDeviceStrategy
    {
        void Update(string json);
        void Listen(string json);
    }
}
