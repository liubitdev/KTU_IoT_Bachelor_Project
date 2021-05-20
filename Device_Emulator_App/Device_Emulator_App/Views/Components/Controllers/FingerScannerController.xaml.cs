using System;
using Device_Emulator_App.ViewModels.Components.Controllers;
using Device_Emulator_App.Views.Components.Controllers;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components.Controllers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FingerScannerController : BasePage
    {
        public FingerScannerViewModel context = new FingerScannerViewModel();
        
        public FingerScannerController()
        {
            InitializeComponent();

            BindingContext = context;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await context.Authorize();
        }
    }
}