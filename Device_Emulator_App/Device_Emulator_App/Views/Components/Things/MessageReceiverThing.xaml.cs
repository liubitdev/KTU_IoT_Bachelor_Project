using System;
using Device_Emulator_App.Models;
using Device_Emulator_App.ViewModels.Components.Things;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components.Things
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageReceiverThing : BasePage
    {
        public MessageReceiverViewModel context = new MessageReceiverViewModel();

        public MessageReceiverThing()
        {
            InitializeComponent();

            ThingsPage.deviceModel.MessageReceived += ReceiveMessage;

            BindingContext = context;
        }

        private void ReceiveMessage(object sender, object data)
        {
            if(data.GetType() != typeof(string))
                context.AddMessage(sender, JsonConvert.SerializeObject(data));
            else context.AddMessage(sender, data);
        }

        private void ClearLog(object sender, EventArgs e)
        {
            context.ClearLog();
        }

    }
}