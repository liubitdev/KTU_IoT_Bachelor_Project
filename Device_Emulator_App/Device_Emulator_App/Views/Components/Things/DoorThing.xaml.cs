using System;
using Device_Emulator_App.ViewModels.Components.Things;
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
        }

        public void ToggleDoorHandler(object sender, EventArgs e)
        {
            context.ToggleDoor();
        }

        public void DoorCloseHandler(object sender, EventArgs e)
        {
            context.CloseDoor();
        }

        public void DoorOpenHandler(object sender, EventArgs e)
        {
            context.OpenDoor();
        }

        public void DoorLockHandler(object sender, EventArgs e)
        {
            context.LockDoor();
        }
        public void DoorUnlockHandler(object sender, EventArgs e)
        {
            context.UnlockDoor();
        }

        public void DoorKnockHandler(object sender, EventArgs e)
        {
            context.Knock();
        }

    }
}