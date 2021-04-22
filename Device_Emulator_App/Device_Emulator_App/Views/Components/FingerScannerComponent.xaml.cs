using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FingerScannerComponent : ContentView
    {
        public FingerScannerComponent()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var availability = await CrossFingerprint.Current.IsAvailableAsync();

            if (!availability)
            {
                await Application.Current.MainPage.DisplayAlert("Warning!", "Cannot read your fingerprint! You may not have it set up.", "OK");
                return;
            }

            var authResult = await CrossFingerprint.Current.AuthenticateAsync(
                new AuthenticationRequestConfiguration("Authorization", "Please use your fingerprint to authorize."));

            if (authResult.Authenticated)
            {
                // TODO: Send call to openHAB
                await Application.Current.MainPage.DisplayAlert("Success!", "Authorized!", "OK");
            }
        }
    }
}