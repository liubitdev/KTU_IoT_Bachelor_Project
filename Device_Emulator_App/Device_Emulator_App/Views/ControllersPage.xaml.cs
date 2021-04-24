using System;
using Device_Emulator_App.ViewModels;
using Device_Emulator_App.Views.Components.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControllersPage : ContentPage
    {
        private Label littleLabel;
        private ControllersViewModel context = new ControllersViewModel();
        public ControllersPage()
        {
            InitializeComponent();

            BindingContext = context;

            devicePicker.Title = "Controllers";
            devicePicker.ItemsSource = context.Lines;
            devicePicker.SetBinding(Picker.ItemsSourceProperty, "Lines");
            devicePicker.SelectedIndexChanged += HandlePickerItemChange;

            littleLabel = new Label();
            littleLabel.Text = context.LittleLabelText;
            littleLabel.HorizontalTextAlignment = TextAlignment.Center;
            littleLabel.VerticalOptions = LayoutOptions.Center;
            littleLabel.HorizontalOptions = LayoutOptions.Center;

            ControllerLayout.Children.Add(littleLabel);
        }

        private async void HandlePickerItemChange(object sender, EventArgs e)
        {
            context.LittleLabelText = devicePicker.SelectedItem.ToString();

            switch (devicePicker.SelectedItem.ToString())
            {
                case "Button":
                    ControllerLayout.Children[1] = new ButtonController();
                    break;
                case "Clock":
                    ControllerLayout.Children[1] = new ClockController();
                    break;
                case "Finger Scanner":
                    ControllerLayout.Children[1] = new FingerScannerController();
                    break;
                case "Pin Code":
                    ControllerLayout.Children[1] = new PinCodeController();
                    break;
                case "Sun Detector":
                    ControllerLayout.Children[1] = new SunDetectorController();
                    break;
                case "Switch":
                    ControllerLayout.Children[1] = new SwitchController();
                    break;
                default:
                    await DisplayAlert("Sorry!", "Invalid selected item!", "OK");
                    break;
            }

        }
    }
}