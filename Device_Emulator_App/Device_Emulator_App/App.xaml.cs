using System;
using System.Net.Http;
using Device_Emulator_App.Models;
using Device_Emulator_App.Models.Network;
using Device_Emulator_App.Services;
using Device_Emulator_App.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App
{
    public partial class App : Application
    {
        private static WebSockets webSockets = new WebSockets();
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ViewModels.Interfaces.IAlertService, Views.Utils.AlertService>();
            webSockets.EstablishConnection();
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
