using System;
using Device_Emulator_App.Models;
using Device_Emulator_App.ViewModels.Components.Things;
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

            BindingContext = context;
        }

        private void ClearLog(object sender, EventArgs e)
        {
            context.ClearLog();
        }

    }
}