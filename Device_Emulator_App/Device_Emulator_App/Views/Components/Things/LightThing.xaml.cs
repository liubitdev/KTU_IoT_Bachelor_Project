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
    public partial class LightThing : BasePage
    {
        public LightViewModel context = new LightViewModel();
        public LightThing()
        {
            InitializeComponent();

            BindingContext = context;
        }

        public void ToggleLight(object sender, EventArgs e)
        {
            context.IsLightOn = !context.IsLightOn;
        }

        public void TurnOnLight(object sender, EventArgs e)
        {
            context.IsLightOn = true;
        }

        public void TurnOffLight(object sender, EventArgs e)
        {
            context.IsLightOn = false;
        }

    }
}