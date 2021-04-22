using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Device_Emulator_App.Views.Components;

namespace Device_Emulator_App.Views
{
    public partial class MainPage : ContentPage
    {
        private Label littleLabel;
        public MainPage()
        {
            InitializeComponent();

            List<string> lines = new List<string>();
            lines.Add("Message Receiver");
            lines.Add("Finger Scanner");
            lines.Add("Window");
            lines.Add("Door");
            lines.Add("Camera");

            devicePicker.Title = "Devices";
            devicePicker.ItemsSource = lines;
            devicePicker.SelectedIndexChanged += HandlePickerItemChange;

            littleLabel = new Label();
            littleLabel.Text = "-";
            deviceControls.Children.Add(littleLabel);
            
        }

        private async void HandlePickerItemChange(object sender, EventArgs e)
        {
            littleLabel.Text = devicePicker.SelectedItem.ToString();

            deviceControls.Children.Clear();
            switch (devicePicker.SelectedItem.ToString())
            {
                case "Finger Scanner":
                    deviceControls.Children.Add(new FingerScannerComponent());
                    break;
                case "Message Receiver":
                    deviceControls.Children.Add(new MessageReceiver());
                    break;
                default:
                    await DisplayAlert("Sorry!", "Invalid selected item!", "OK");
                    break;
            }

        }
    }
}