using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Device_Emulator_App.ViewModels.Components.Controllers
{
    public class PinCodeViewModel : BaseViewModel
    {
        private string pinInput = "";
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

        }

        public void PinNumberButtonHandler(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Console.WriteLine(button.ClassId);
            if (PinInput.Length < 4)
            {
                PinInput += button.ClassId.ToString();
            }
        }

        public async void SubmitButtonHandler(object sender, EventArgs e)
        {
            //await webSockets.SendData("");
        }

        public async void DeleteButtonHandler(object sender, EventArgs e)
        {
            if (PinInput.Length != 0)
            {
                PinInput = PinInput.Substring(0, PinInput.Length - 1);
            }
        }

    }
}
