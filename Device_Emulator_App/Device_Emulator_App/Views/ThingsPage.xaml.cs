using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Device_Emulator_App.Views.Components;
using Device_Emulator_App.Views.Components.Things;
using Device_Emulator_App.ViewModels;

namespace Device_Emulator_App.Views
{
    public partial class ThingsPage : ContentPage
    {
        private Label littleLabel;
        private ThingsViewModel context = new ThingsViewModel();
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

        private async void HandlePickerItemChange(object sender, EventArgs e)
        {
            context.LittleLabelText = devicePicker.SelectedItem.ToString();

            switch (devicePicker.SelectedItem.ToString())
            {
                case "Message Receiver":
                    ThingsLayout.Children[1] = new MessageReceiverThing();
                    break;
                case "Window":
                    ThingsLayout.Children[1] = new WindowThing();
                    break;
                case "Door":
                    ThingsLayout.Children[1] = new DoorThing();
                    break;
                case "Mailbox":
                    ThingsLayout.Children[1] = new MailboxThing();
                    break;
                default:
                    await DisplayAlert("Sorry!", "Invalid selected item!", "OK");
                    break;
            }

        }
    }
}