using System;
using System.Collections.Generic;
using Device_Emulator_App.ViewModels;
using Device_Emulator_App.Views;
using Xamarin.Forms;

namespace Device_Emulator_App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            ThingsTab.Icon = ImageSource.FromResource("Device_Emulator_App.Resources.baseline_widgets_black_48.png");
            ControllersTab.Icon = ImageSource.FromResource("Device_Emulator_App.Resources.baseline_settings_remote_black_48.png");
        }

    }
}
