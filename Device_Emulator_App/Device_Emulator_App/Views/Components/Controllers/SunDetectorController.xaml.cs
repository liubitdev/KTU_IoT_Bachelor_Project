using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Device_Emulator_App.ViewModels;
using Device_Emulator_App.ViewModels.Components.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components.Controllers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SunDetectorController : BasePage
    {
        public SunDetectorViewModel context = new SunDetectorViewModel();
        public SunDetectorController()
        {
            InitializeComponent();

            BindingContext = context;
        }

        private void SliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            Slider slider = (Slider)sender;
            float sliderValue = (float)slider.Value;
            context.SliderValue = sliderValue;
        }
    }
}