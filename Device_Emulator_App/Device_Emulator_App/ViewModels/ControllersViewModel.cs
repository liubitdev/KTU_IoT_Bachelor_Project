using System;
using System.Collections.Generic;
using System.Text;
using Device_Emulator_App.ViewModels.Interfaces;
using Device_Emulator_App.Views.Components;
using Device_Emulator_App.Views.Components.Controllers;
using Xamarin.Forms;

namespace Device_Emulator_App.ViewModels
{
    public class ControllersViewModel : BaseViewModel
    {
        private readonly IAlertService alertService;
        private string littleLabelText;
        public string LittleLabelText
        {
            get { return littleLabelText; }
            set { SetProperty(ref littleLabelText, value); }
        }

        public List<string> Lines { set; get; }

        public ControllersViewModel()
        {
            Lines = new List<string>();
            Lines.Add("Button");
            Lines.Add("Clock");
            Lines.Add("Finger Scanner");
            Lines.Add("Pin Code");
            Lines.Add("Sun Detector");
            Lines.Add("Switch");

            LittleLabelText = "Please select a controller :)\nControllers control your house devices\nHow neat! ^-^";
        }
    }
}
