using System;
using Device_Emulator_App.Models;
using Device_Emulator_App.Models.Enums;
using Device_Emulator_App.ViewModels;
using Device_Emulator_App.Views.Components.Controllers;
using Xamarin.Forms;

namespace Device_Emulator_App.Views
{
    public partial class ControllersPage : ContentPage
    {
        public static ControllerDeviceModel deviceModel = new ControllerDeviceModel();

        private ControllersViewModel context = new ControllersViewModel();
        private EDeviceType selectionType;
        public ControllersPage()
        {
            InitializeComponent();

            BindingContext = context;

            devicePicker.Title = "Controllers";
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
            deviceModel.ConfigureController(selectionType);
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
                case EDeviceType.BUTTON:
                    await Navigation.PushAsync(new ButtonController());
                    break;
                case EDeviceType.FINGERSCANNER:
                    await Navigation.PushAsync(new FingerScannerController());
                    break;
                case EDeviceType.MAILBOX:
                    await Navigation.PushAsync(new MailboxController());
                    break;
                case EDeviceType.PINCODE:
                    await Navigation.PushAsync(new PinCodeController());
                    break;
                case EDeviceType.SUNDETECTOR:
                    await Navigation.PushAsync(new SunDetectorController());
                    break;
                case EDeviceType.SWITCH:
                    await Navigation.PushAsync(new SwitchController());
                    break;
                default:
                    break;
            }
        }

        private async void HandlePickerItemChange(object sender, EventArgs e)
        {
            switch (devicePicker.SelectedItem.ToString())
            {
                case "Button":
                    selectionType = EDeviceType.BUTTON;
                    break;
                case "Finger Scanner":
                    selectionType = EDeviceType.FINGERSCANNER;
                    break;
                case "Mailbox":
                    selectionType = EDeviceType.MAILBOX;
                    break;
                case "Pin Code":
                    selectionType = EDeviceType.PINCODE;
                    break;
                case "Sun Detector":
                    selectionType = EDeviceType.SUNDETECTOR;
                    break;
                case "Switch":
                    selectionType = EDeviceType.SWITCH;
                    break;
                default:
                    await DisplayAlert("Sorry!", "Invalid selected item!", "OK");
                    break;
            }

        }
    }
}