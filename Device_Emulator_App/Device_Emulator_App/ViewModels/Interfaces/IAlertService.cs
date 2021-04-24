using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Device_Emulator_App.ViewModels.Interfaces
{
    interface IAlertService
    {
        Task ShowAlertAsync(string alertTitle, string alertText, string buttonText);
    }
}
