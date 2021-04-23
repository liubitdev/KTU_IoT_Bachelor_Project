using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Device_Emulator_App.Views.Components;

namespace Device_Emulator_App.Views
{
    public partial class DevicesPage : ContentPage
    {
        private Label littleLabel;
        public DevicesPage()
        {
            InitializeComponent();

            List<string> lines = new List<string>();
            lines.Add("Message Receiver");
            lines.Add("Window");
            lines.Add("Door");
            lines.Add("Mailbox");

            devicePicker.Title = "Devices";
            devicePicker.ItemsSource = lines;
            devicePicker.SelectedIndexChanged += HandlePickerItemChange;

            littleLabel = new Label();
            littleLabel.Text = "Please select a device :)\nDevices react to your set of rules\nPowerful! \\o/";
            littleLabel.HorizontalTextAlignment = TextAlignment.Center;
            littleLabel.VerticalOptions = LayoutOptions.Center;
            littleLabel.HorizontalOptions = LayoutOptions.Center;
            deviceControls.Children.Add(littleLabel);
        }

        private async void HandlePickerItemChange(object sender, EventArgs e)
        {
            littleLabel.Text = devicePicker.SelectedItem.ToString();

            deviceControls.Children.Clear();
            switch (devicePicker.SelectedItem.ToString())
            {
                case "Message Receiver":
                    deviceControls.Children.Add(new MessageReceiver());
                    break;
                case "Window":
                    deviceControls.Children.Add(new WindowComponent());
                    break;
                case "Door":
                    deviceControls.Children.Add(new DoorComponent());
                    break;
                case "Mailbox":
                    deviceControls.Children.Add(new Mailbox());
                    break;
                default:
                    await DisplayAlert("Sorry!", "Invalid selected item!", "OK");
                    break;
            }

        }
    }
}