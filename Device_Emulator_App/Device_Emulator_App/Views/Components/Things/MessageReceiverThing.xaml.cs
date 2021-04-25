using System;
using Device_Emulator_App.Models;
using Device_Emulator_App.Models.Network;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components.Things
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageReceiverThing : ContentPage
    {
        private static WebSockets webSockets = new WebSockets();
        private string displayedMessage;
        public string DisplayedMessage {
            get { return displayedMessage; }
            set
            {
                displayedMessage = value;
                OnPropertyChanged(nameof(DisplayedMessage)); // Notify that there was a change on this property
            }
        }

        public MessageReceiverThing()
        {
            InitializeComponent();

            DeviceModel.StatesChanged += (sender, data) =>
            {
                DisplayedMessage = JsonConvert.SerializeObject(data);
            };

            DisplayedMessage = "Received message goes here!";
            BindingContext = this;
        }
        private void ClientConnect(object sender, EventArgs e)
        {
            webSockets.EstablishConnection();
        }

        private async void ClientSend(object sender, EventArgs e)
        {
            await webSockets.SendData("{\"message\":\"Hello World!\"}");
        }

    }
}