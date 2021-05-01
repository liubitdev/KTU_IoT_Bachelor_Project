﻿using System;
using Device_Emulator_App.Models;
using Device_Emulator_App.ViewModels;
using Device_Emulator_App.Views.Components.Controllers;
using Xamarin.Forms;

namespace Device_Emulator_App.Views
{
    public partial class ControllersPage : ContentPage
    {
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
            if (DeviceModel.Group == Models.Enums.EDeviceGroup.NONE) return;
            await DeviceModel.Create();

            if (DeviceModel.NetworkState != Models.Enums.EDeviceNetworkState.ONLINE) return;

            switch (DeviceModel.Group)
            {
                case Models.Enums.EDeviceGroup.BUTTON:
                    await Navigation.PushAsync(new ButtonController());
                    break;
                case Models.Enums.EDeviceGroup.FINGERSCANNER:
                    await Navigation.PushAsync(new FingerScannerController());
                    break;
                case Models.Enums.EDeviceGroup.MAILBOX:
                    await Navigation.PushAsync(new MailboxController());
                    break;
                case Models.Enums.EDeviceGroup.PINCODE:
                    await Navigation.PushAsync(new PinCodeController());
                    break;
                case Models.Enums.EDeviceGroup.SUNDETECTOR:
                    await Navigation.PushAsync(new SunDetectorController());
                    break;
                case Models.Enums.EDeviceGroup.SWITCH:
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
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.CONTROLLER, Models.Enums.EDeviceGroup.BUTTON);
                    break;
                case "Finger Scanner":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.CONTROLLER, Models.Enums.EDeviceGroup.FINGERSCANNER);
                    break;
                case "Mailbox":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.CONTROLLER, Models.Enums.EDeviceGroup.MAILBOX);
                    break;
                case "Pin Code":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.CONTROLLER, Models.Enums.EDeviceGroup.PINCODE);
                    break;
                case "Sun Detector":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.CONTROLLER, Models.Enums.EDeviceGroup.SUNDETECTOR);
                    break;
                case "Switch":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.CONTROLLER, Models.Enums.EDeviceGroup.SWITCH);
                    break;
                default:
                    await DisplayAlert("Sorry!", "Invalid selected item!", "OK");
                    break;
            }

        }
    }
}