using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Device_Emulator_App.ViewModels.Components.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components.Controllers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwitchController : BasePage
    {
        public SwitchViewModel context = new SwitchViewModel();
        public SwitchController()
        {
            InitializeComponent();

            BindingContext = context;
        }

        public void OnChange(object sender, EventArgs e)
        {
            Switch switchController = (Switch)sender;

            context.IsEnabled = switchController.IsEnabled;
        }

    }
}