using System;
using Xamarin.Forms;
using Device_Emulator_App.Views.Components.Things;
using Device_Emulator_App.ViewModels;
using Device_Emulator_App.Models;

namespace Device_Emulator_App.Views
{
    public partial class ThingsPage : ContentPage
    {
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
                case Models.Enums.EDeviceGroup.MESSAGE_RECEIVER:
                    await Navigation.PushAsync(new MessageReceiverThing(), true);
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
                default:
                    break;
            }
        }

        private async void HandlePickerItemChange(object sender, EventArgs e)
        {
            selectionName = devicePicker.SelectedItem.ToString();

            switch (devicePicker.SelectedItem.ToString())
            {
                case "Door":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.THING, Models.Enums.EDeviceGroup.DOOR);
                    break;
                case "Light":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.THING, Models.Enums.EDeviceGroup.LIGHT);
                    break;
                case "Message Receiver":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.THING, Models.Enums.EDeviceGroup.MESSAGE_RECEIVER);
                    break;
                case "TV":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.THING, Models.Enums.EDeviceGroup.TV);
                    break;
                case "Window":
                    DeviceModel.Configure(selectionName, Models.Enums.EDeviceType.THING, Models.Enums.EDeviceGroup.WINDOW);
                    break;
                default:
                    await DisplayAlert("Sorry!", "Invalid selected item!", "OK");
                    break;
            }
        }
    }
}