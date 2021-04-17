using System;
using System.Collections.Generic;
using System.ComponentModel;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views
{
    public partial class MainPage : ContentPage
    {
        private Label littleLabel;
        public MainPage()
        {
            InitializeComponent();

            List<string> lines = new List<string>();
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

            if(devicePicker.SelectedItem.ToString() == "Finger Scanner") {
                var availability = await CrossFingerprint.Current.IsAvailableAsync();

                if(!availability) {
                    await DisplayAlert("Warning!", "Cannot read fingerprint!", "OK");
                    return;
                }

                var authResult = await CrossFingerprint.Current.AuthenticateAsync(
                    new AuthenticationRequestConfiguration("Heads up!", "I would like to use your biometrics."));

                if (authResult.Authenticated)
                {
                    await DisplayAlert("Success!", "Success!", "OK");
                }
            }

        }
    }
}