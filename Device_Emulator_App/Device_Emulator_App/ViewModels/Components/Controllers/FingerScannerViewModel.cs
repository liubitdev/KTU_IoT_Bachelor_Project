using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Device_Emulator_App.Views;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.ViewModels.Components.Controllers
{
    public class FingerScannerViewModel : BaseViewModel
    {
        private bool isPinCodeInputVisible;
        public bool IsPinCodeInputVisible
        {
            get { return isPinCodeInputVisible; }
            set
            {
                SetProperty(ref isPinCodeInputVisible, value);
            }
        }

        public FingerScannerViewModel()
        {
            IsPinCodeInputVisible = false;
        }

        public async Task Authorize()
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
                // TODO: Send call to HUB
                ControllersPage.deviceModel.SendMessage("{\"message\":\"authenticated!\"}");

                await Application.Current.MainPage.DisplayAlert("Success!", "Authorized!", "OK");
            }
            else
            {
                if (!IsPinCodeInputVisible)
                {
                    //ComponentContainer.Children.Add(new PinCodeController());
                    IsPinCodeInputVisible = true;
                }
            }
        }


    }
}
