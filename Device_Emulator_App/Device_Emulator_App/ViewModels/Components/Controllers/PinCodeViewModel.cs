using System;
using System.Collections.Generic;
using System.Text;
using Device_Emulator_App.Views;
using Xamarin.Forms;

namespace Device_Emulator_App.ViewModels.Components.Controllers
{
    public class PinCodeViewModel : BaseViewModel
    {
        private string pinInput;
        public string PinInput
        {
            get
            {
                return pinInput;
            }
            set
            {
                pinInput = value;
                OnPropertyChanged(nameof(PinInput)); // Notify that there was a change on this property
            }
        }

        public PinCodeViewModel()
        {
            PinInput = "";
        }

        public void PinNumberButtonHandler(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (PinInput.Length < 4)
            {
                PinInput += button.ClassId.ToString();
            }
        }

        public void SubmitButtonHandler()
        {
            // TODO: Make it into an acceptable message format
            ControllersPage.deviceModel.SendMessage("{\"message\":\"" + PinInput + "\"}");
        }

        public void DeleteButtonHandler()
        {
            if (PinInput.Length != 0)
            {
                PinInput = PinInput.Substring(0, PinInput.Length - 1);
            }
        }

    }
}
