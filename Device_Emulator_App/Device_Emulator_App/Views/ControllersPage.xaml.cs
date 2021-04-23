using System;
using System.Collections.Generic;
using Device_Emulator_App.Views.Components;
using Device_Emulator_App.Views.Components.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControllersPage : ContentPage
    {
        private Label littleLabel;
        public ControllersPage()
        {
            InitializeComponent();

            List<string> lines = new List<string>();
            lines.Add("Camera");
            lines.Add("Finger Scanner");
            lines.Add("Pin Code");
            lines.Add("Switch");

            devicePicker.Title = "Devices";
            devicePicker.ItemsSource = lines;
            devicePicker.SelectedIndexChanged += HandlePickerItemChange;

            littleLabel = new Label();
            littleLabel.Text = "Please select a controller :)\nControllers control your house devices\nHow neat! ^-^";
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
                case "Camera":
                    deviceControls.Children.Add(new CameraComponent());
                    break;
                case "Finger Scanner":
                    deviceControls.Children.Add(new FingerScannerComponent());
                    break;
                case "Pin Code":
                    deviceControls.Children.Add(new PinCodeComponent());
                    break;
                case "Switch":
                    deviceControls.Children.Add(new Switch());
                    break;
                default:
                    await DisplayAlert("Sorry!", "Invalid selected item!", "OK");
                    break;
            }

        }
    }
}