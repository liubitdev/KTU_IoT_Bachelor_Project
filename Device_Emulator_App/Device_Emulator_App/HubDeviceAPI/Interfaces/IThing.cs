using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Device_Emulator_App.HubDeviceAPI.Interfaces
{
    interface IThing
    {
        void NotifyState(string json);
        void ReceiveMessage(object sender, string message);
    }
}
