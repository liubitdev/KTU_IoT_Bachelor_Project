using System;
using Device_Emulator_App.Services;
using Device_Emulator_App.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
