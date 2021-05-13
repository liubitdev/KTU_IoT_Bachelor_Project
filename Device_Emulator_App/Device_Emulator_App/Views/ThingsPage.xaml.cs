using System;
using Xamarin.Forms;
using Device_Emulator_App.Views.Components.Things;
using Device_Emulator_App.ViewModels;
using Device_Emulator_App.Models;
using Device_Emulator_App.Models.Enums;

namespace Device_Emulator_App.Views
{
    public partial class ThingsPage : ContentPage
    {
        public static ThingDeviceModel deviceModel = new ThingDeviceModel();

        private ThingsViewModel context = new ThingsViewModel();
        private EDeviceType selectionType;
        public ThingsPage()
        {
            InitializeComponent();

            BindingContext = context;

            devicePicker.Title = "Things";
            devicePicker.ItemsSource = context.Lines;
            devicePicker.SetBinding(Picker.ItemsSourceProperty, "Lines");
            devicePicker.SelectedIndexChanged += HandlePickerItemChange;

            pickerDescription.Text = context.LittleLabelText;
            pickerDescription.HorizontalTextAlignment = TextAlignment.Center;
            pickerDescription.VerticalOptions = LayoutOptions.Center;
            pickerDescription.HorizontalOptions = LayoutOptions.Center;
        }

        private async void ConfirmButtonHandler(object sender, EventArgs e)
        {
            if (selectionType == EDeviceType.NONE)
            {
                await DisplayAlert("Selection not found", "Please select a device which you want to simulate from the list!", "Gotcha!");
                return;
            }

            // TODO: Move to switch statement cases
            // TODO: Add possible funcions list to every Thing Configuration
            deviceModel.ConfigureThing(selectionType);
            try
            {
                Uri ipAddress = new Uri(ipAdressInput.Text + ":" + portInput.Text);
                if (await deviceModel.ConnectToServer(ipAddress) != 1)
                {
                    throw new Exception();
                }
            }
            catch
            {
                await DisplayAlert("Error", "Couldn't connect to the server :(", "Okay :(");
                return;
            }

            switch (deviceModel.Type)
            {
                case EDeviceType.MESSAGE_RECEIVER:
                    await Navigation.PushAsync(new MessageReceiverThing(), true);
                    break;
                case EDeviceType.LIGHT:
                    await Navigation.PushAsync(new LightThing(), true);
                    break;
                case EDeviceType.WINDOW:
                    await Navigation.PushAsync(new WindowThing(), true);
                    break;
                case EDeviceType.DOOR:
                    await Navigation.PushAsync(new DoorThing(), true);
                    break;
                case EDeviceType.TV:
                    await Navigation.PushAsync(new TvThing(), true);
                    break;
                default:
                    break;
            }
        }

        private async void HandlePickerItemChange(object sender, EventArgs e)
        {
            switch (devicePicker.SelectedItem.ToString())
            {
                case "Door":
                    selectionType = EDeviceType.DOOR;
                    break;
                case "Light":
                    selectionType = EDeviceType.LIGHT;
                    break;
                case "Message Receiver":
                    selectionType = EDeviceType.MESSAGE_RECEIVER;
                    break;
                case "TV":
                    selectionType = EDeviceType.TV;
                    break;
                case "Window":
                    selectionType = EDeviceType.WINDOW;
                    break;
                default:
                    await DisplayAlert("Sorry!", "Invalid selected item!", "OK");
                    break;
            }
        }
    }
}