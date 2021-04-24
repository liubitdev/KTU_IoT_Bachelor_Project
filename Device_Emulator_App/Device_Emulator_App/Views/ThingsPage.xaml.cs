using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Device_Emulator_App.Views.Components;
using Device_Emulator_App.Views.Components.Things;
using Device_Emulator_App.ViewModels;
using Device_Emulator_App.Models;

namespace Device_Emulator_App.Views
{
    public partial class ThingsPage : ContentPage
    {
        private Label littleLabel;
        private ThingsViewModel context = new ThingsViewModel();

        private string selectionName;
        public ThingsPage()
        {
            InitializeComponent();

            BindingContext = context;

            devicePicker.Title = "Things";
            devicePicker.ItemsSource = context.Lines;
            devicePicker.SetBinding(Picker.ItemsSourceProperty, "Lines");
            devicePicker.SelectedIndexChanged += HandlePickerItemChange;

            littleLabel = new Label();
            littleLabel.Text = context.LittleLabelText;
            littleLabel.HorizontalTextAlignment = TextAlignment.Center;
            littleLabel.VerticalOptions = LayoutOptions.Center;
            littleLabel.HorizontalOptions = LayoutOptions.Center;

            ThingsLayout.Children.Add(littleLabel);
        }

        private async void ConfirmButtonHandler(object sender, EventArgs e)
        {
            if (DeviceModel.Group == Models.Enums.EDeviceGroup.NONE) return;
            DeviceModel.Create();

            switch (DeviceModel.Group)
            {
                case Models.Enums.EDeviceGroup.MESSAGE_RECEIVER:
                    await Navigation.PushAsync(new MessageReceiverThing());
                    break;
                case Models.Enums.EDeviceGroup.LIGHT:
                    await Navigation.PushAsync(new LightThing());
                    break;
                case Models.Enums.EDeviceGroup.WINDOW:
                    await Navigation.PushAsync(new WindowThing());
                    break;
                case Models.Enums.EDeviceGroup.DOOR:
                    await Navigation.PushAsync(new DoorThing());
                    break;
                case Models.Enums.EDeviceGroup.TV:
                    await Navigation.PushAsync(new TvThing());
                    break;
                case Models.Enums.EDeviceGroup.MAILBOX:
                    await Navigation.PushAsync(new MailboxThing());
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
                case "Message Receiver":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.THING, Models.Enums.EDeviceGroup.MESSAGE_RECEIVER);
                    break;
                case "Light":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.THING, Models.Enums.EDeviceGroup.LIGHT);
                    break;
                case "Window":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.THING, Models.Enums.EDeviceGroup.WINDOW);
                    break;
                case "Door":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.THING, Models.Enums.EDeviceGroup.DOOR);
                    break;
                case "TV":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.THING, Models.Enums.EDeviceGroup.TV);
                    break;
                case "Mailbox":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.THING, Models.Enums.EDeviceGroup.MAILBOX);
                    break;
                default:
                    await DisplayAlert("Sorry!", "Invalid selected item!", "OK");
                    break;
            }
        }
    }
}