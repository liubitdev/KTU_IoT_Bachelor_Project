using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Device_Emulator_App.ViewModels.Interfaces;

namespace Device_Emulator_App.Views.Utils
{
    class AlertService : IAlertService
    {
        public async Task ShowAlertAsync(string alertTitle, string alertText, string buttonText)
        {
            await App.Current.MainPage.DisplayAlert(alertTitle, alertText, buttonText);
        }
    }
}
