using Device_Emulator_App.ViewModels.Components.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components.Controllers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonController : BasePage
    {
        public ButtonViewModel context = new ButtonViewModel();
        public ButtonController()
        {
            InitializeComponent();

            BindingContext = context;
        }

        private void ButtonClickHandler(object sender, EventArgs e)
        {
            context.SendMessage();
        }
    }
}