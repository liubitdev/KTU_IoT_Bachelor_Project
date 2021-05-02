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
    public partial class WindowThing : BasePage
    {
        WindowViewModel context = new WindowViewModel();
        public WindowThing()
        {
            InitializeComponent();

            BindingContext = context;
        }

        public void WindowOpenHandler(object sender, EventArgs e)
        {
            context.OpenWindow();
        }

        public void WindowCloseHandler(object sender, EventArgs e)
        {
            context.CloseWindow();
        }

        public void WindowBreakHandler(object sender, EventArgs e)
        {
            context.BreakWindow();
        }

    }
}