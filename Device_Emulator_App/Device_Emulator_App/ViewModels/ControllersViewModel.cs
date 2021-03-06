using System.Collections.Generic;

namespace Device_Emulator_App.ViewModels
{
    public class ControllersViewModel : BaseViewModel
    {
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
            Lines.Add("Finger Scanner");
            Lines.Add("Mailbox");
            Lines.Add("Pin Code");
            Lines.Add("Sun Detector");
            Lines.Add("Switch");

            LittleLabelText = "Please select a controller :)\nControllers control your house devices\nHow neat! ^-^";
        }
    }
}
