using System;
using System.Collections.Generic;
using System.Text;

namespace Device_Emulator_App.HubDeviceAPI.Interfaces
{
    interface IController
    {
        void SendMessage(string json);
    }
}
