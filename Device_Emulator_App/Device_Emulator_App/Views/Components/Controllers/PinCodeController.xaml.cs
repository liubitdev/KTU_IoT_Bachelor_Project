﻿using System;
using Device_Emulator_App.ViewModels.Components.Controllers;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components.Controllers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinCodeController : BasePage
    {
        public PinCodeViewModel context = new PinCodeViewModel();

        public PinCodeController()
        {
            InitializeComponent();

            BindingContext = context;
        }

        public void PinNumberButtonHandler(object sender, EventArgs e)
        {
            context.PinNumberButtonHandler(sender, e);
        }

        public async void SubmitButtonHandler(object sender, EventArgs e)
        {
            //await webSockets.SendData("");
        }

        public async void DeleteButtonHandler(object sender, EventArgs e)
        {
            context.DeleteButtonHandler(sender, e);
        }

    }
}