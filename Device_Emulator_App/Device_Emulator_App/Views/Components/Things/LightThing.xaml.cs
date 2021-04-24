using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Device_Emulator_App.ViewModels.Components.Things;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components.Things
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LightThing : ContentPage
    {
        public LightViewModel context = new LightViewModel();
        public LightThing()
        {
            InitializeComponent();

            BindingContext = context;
            context.IsLightOn = false;
        }

        public void ToggleLight()
        {
            context.IsLightOn = !context.IsLightOn;
        }

        public void TurnOnLight()
        {
            context.IsLightOn = true;
        }

        public void TurnOffLight()
        {
            context.IsLightOn = false;
        }
    }
}