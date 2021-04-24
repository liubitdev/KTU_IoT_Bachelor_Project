using System;
using System.Collections.Generic;
using System.Text;

namespace Device_Emulator_App.ViewModels.Components.Controllers
{
    public class SunDetectorViewModel : BaseViewModel
    {
        private float sliderValue = 0;
        public float SliderValue
        {
            get { return sliderValue; }
            set { 
                SetProperty(ref sliderValue, value);
                BackgroundColor = new Xamarin.Forms.Color(value, value, value);
            }
        }

        private Xamarin.Forms.Color backgroundColor = Xamarin.Forms.Color.Black;
        public Xamarin.Forms.Color BackgroundColor
        {
            get { return backgroundColor; }
            set { SetProperty(ref backgroundColor, value); }
        }
        public SunDetectorViewModel()
        {

        }

    }
}
