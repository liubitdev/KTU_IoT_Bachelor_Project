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
        public static ControllerDeviceModel deviceModel;

        private ControllersViewModel context = new ControllersViewModel();
        private string selectionName;
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
            deviceModel = new ControllerDeviceModel();

            if (DeviceModel.Type == EDeviceType.NONE) return;
            await DeviceModel.Create();

            if (DeviceModel.NetworkState != Models.Enums.EDeviceNetworkState.ONLINE) return;

            switch (DeviceModel.Type)
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
            selectionName = devicePicker.SelectedItem.ToString();

            switch (devicePicker.SelectedItem.ToString())
            {
                case "Button":
                    deviceModel.ConfigureController(EDeviceType.BUTTON);
                    break;
                case "Finger Scanner":
                    deviceModel.ConfigureController(EDeviceType.FINGERSCANNER);
                    break;
                case "Mailbox":
                    deviceModel.ConfigureController(EDeviceType.MAILBOX);
                    break;
                case "Pin Code":
                    deviceModel.ConfigureController(EDeviceType.PINCODE);
                    break;
                case "Sun Detector":
                    deviceModel.ConfigureController(EDeviceType.SUNDETECTOR);
                    break;
                case "Switch":
                    deviceModel.ConfigureController(EDeviceType.SWITCH);
                    break;
                default:
                    await DisplayAlert("Sorry!", "Invalid selected item!", "OK");
                    break;
            }

        }
    }
}