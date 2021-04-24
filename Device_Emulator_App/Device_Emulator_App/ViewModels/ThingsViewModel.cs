using System;
using System.Collections.Generic;
using System.Text;
using Device_Emulator_App.ViewModels.Interfaces;

namespace Device_Emulator_App.ViewModels
{
    class ThingsViewModel : BaseViewModel
    {
        private readonly IAlertService alertService;
        private string littleLabelText;
        public string LittleLabelText
        {
            get { return littleLabelText; }
            set { SetProperty(ref littleLabelText, value); }
        }

        public List<string> Lines { set; get; }

        public ThingsViewModel()
        {
            Lines = new List<string>();
            Lines.Add("Door");
            Lines.Add("Mailbox");
            Lines.Add("Message Receiver");
            Lines.Add("Window");

            LittleLabelText = "Please select a thing :)\nThings react to your set of rules\nPowerful! \\o/";
        }
    }
}
