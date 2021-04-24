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
    public partial class DoorThing : ContentView
    {
        public DoorViewModel context = new DoorViewModel();
        public DoorThing()
        {
            InitializeComponent();

            BindingContext = context;
            context.IsDoorOpen = false;
        }

        public void ToggleDoor()
        {
            context.IsDoorOpen = !context.IsDoorOpen;
        }

        public void OpenDoor()
        {
            context.IsDoorOpen = true;
        }

        public void CloseDoor()
        {
            context.IsDoorOpen = false;
        }
    }
}