using Device_Emulator_App.Models;
using Xamarin.Forms;

namespace Device_Emulator_App.Views
{
    public class BasePage : ContentPage
    {
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                if (await DisplayAlert("Warning!", "Do you really want to exit?", "Yes", "No"))
                {
                    //DeviceModel.ClearSubscriptions();
                    await Navigation.PopAsync();
                }
            });
            return true;
        }
    }
}