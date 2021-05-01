using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
