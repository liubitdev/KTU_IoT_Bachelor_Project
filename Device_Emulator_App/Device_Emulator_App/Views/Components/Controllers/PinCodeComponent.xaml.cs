using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Device_Emulator_App.Models.Network;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components.Controllers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinCodeComponent : ContentView
    {
        private static WebSockets webSockets = new WebSockets();
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

        public PinCodeComponent()
        {
            InitializeComponent();

            BindingContext = this;
        }

        private void PinNumberButtonHandler(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Console.WriteLine(button.ClassId);
            PinInput += button.ClassId.ToString();
        }

        private async void SubmitButtonHandler(object sender, EventArgs e)
        {
            //await webSockets.SendData("");
        }
    }
}