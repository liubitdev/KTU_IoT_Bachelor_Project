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
    public partial class DoorThing : BasePage
    {
        public DoorViewModel context = new DoorViewModel();
        public DoorThing()
        {
            InitializeComponent();

            BindingContext = context;

            context.OpenDoor();

        }

        public void ToggleDoor()
        {
            context.ToggleDoor();
        }

        public void CloseDoor()
        {
            context.CloseDoor();
        }

        public void DoorOpenButtonHandler(object sender, EventArgs e)
        {
            context.OpenDoor();
        }

    }
}