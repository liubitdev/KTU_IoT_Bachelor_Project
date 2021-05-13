using System;
using System.Collections.Generic;
using System.Text;
using Device_Emulator_App.Models;
using Device_Emulator_App.Views;

namespace Device_Emulator_App.ViewModels.Components.Things
{
    public class DoorViewModel : BaseViewModel
    {
        string labelText = "Door is closed and Locked!";
        public string LabelText
        {
            get { return labelText; }
            set { SetProperty(ref labelText, value); }
        }
        bool isDoorOpen = false;
        public bool IsDoorOpen
        {
            get { return isDoorOpen; }
            set
            {
                SetProperty(ref isDoorOpen, value);
                if (IsDoorOpen)
                {
                    DoorColor = Xamarin.Forms.Color.SandyBrown;
                    LabelText = "Door is open!";
                    LabelColor = Xamarin.Forms.Color.Black;

                }
                else
                {
                    DoorColor = Xamarin.Forms.Color.SaddleBrown;
                    if (IsDoorUnlocked) LabelText = "Door is Closed and Unlocked!";
                    else LabelText = "Door is Closed and Locked!";
                    LabelColor = Xamarin.Forms.Color.White;
                }
            }
        }

        bool isDoorUnLocked = false;
        public bool IsDoorUnlocked
        {
            get { return isDoorUnLocked; }
            set
            {
                SetProperty(ref isDoorUnLocked, value);
                if (value) LabelText = "Door is Closed and Unlocked!";
                else LabelText = "Door is Closed and Locked!";
            }
        }

        private Xamarin.Forms.Color labelColor;
        public Xamarin.Forms.Color LabelColor
        {
            get { return labelColor; }
            set { SetProperty(ref labelColor, value); }
        }

        private Xamarin.Forms.Color doorColor;
        public Xamarin.Forms.Color DoorColor
        {
            get { return doorColor; }
            set { SetProperty(ref doorColor, value); }
        }

        private bool isKnocked;
        public bool IsKnocked
        {
            get { return isKnocked; }
            set { SetProperty(ref isKnocked, value); }
        }

        public DoorViewModel()
        {
            CloseDoor();
            LockDoor();

            ThingsPage.deviceModel.MessageReceived += ReceiveMessage;
        }

        private void ReceiveMessage(object sender, string message)
        {
            // TODO: Implement more accurate received message handling
            if (message.GetType() == typeof(string))
                ToggleDoor();

        }

        public void ToggleDoor()
        {
            IsDoorOpen = !IsDoorOpen;
        }

        public void OpenDoor()
        {
            if (IsDoorUnlocked)
                IsDoorOpen = true;
        }

        public void CloseDoor()
        {
            IsDoorOpen = false;
        }

        public void UnlockDoor()
        {
            IsDoorUnlocked = true;
        }

        public void LockDoor()
        {
            if (!IsDoorOpen)
                IsDoorUnlocked = false;
        }

        public void Knock()
        {
            IsKnocked = true;
        }

    }
}
