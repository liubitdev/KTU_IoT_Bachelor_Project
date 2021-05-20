using System;
using System.Collections.Generic;
using System.Text;
using Device_Emulator_App.Views;

namespace Device_Emulator_App.ViewModels.Components.Controllers
{
    public class SwitchViewModel : BaseViewModel
    {
        private bool isEnabled;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                SetProperty(ref isEnabled, value);
                ChangedValueHandler();
            }
        }

        public SwitchViewModel()
        {
            IsEnabled = false;
        }

        public void SwitchEnable()
        {
            IsEnabled = true;
        }

        public void SwitchDisable()
        {
            IsEnabled = false;
        }

        public void ChangedValueHandler()
        {
            // TODO: Make it into an acceptable message format
            ControllersPage.deviceModel.SendMessage("{\"message\":\"" + IsEnabled + "\"}");
        }

    }
}
