using System;
using System.Collections.Generic;

namespace Device_Emulator_App.Models.Interfaces
{
    public interface ISubscribable
    {
        event EventHandler<Dictionary<string, string>> StatesChanged;
    }
}
