using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoorComponent : ContentView
    {
        private bool doorOpen;
        public bool DoorOpen
        {
            get { return doorOpen; }
            set
            {
                doorOpen = value;
                OnPropertyChanged(nameof(DoorOpen)); // Notify that there was a change on this property
            }
        }
        public DoorComponent()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public void ToggleDoor()
        {
            DoorOpen = !DoorOpen;
        }

        public void OpenDoor()
        {
            DoorOpen = true;
        }

        public void CloseDoor()
        {
            DoorOpen = false;
        }
    }
}