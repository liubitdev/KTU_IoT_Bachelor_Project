using System;
using System.Collections.Generic;

namespace Device_Emulator_App.HubDeviceAPI.Interfaces
{
    public interface ISubscribable
    {
        event EventHandler<Dictionary<string, string>> StatesChanged;
    }
}
