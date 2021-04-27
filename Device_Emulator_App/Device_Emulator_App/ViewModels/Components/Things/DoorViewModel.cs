﻿using System;
using System.Collections.Generic;
using System.Text;
using Device_Emulator_App.Models;

namespace Device_Emulator_App.ViewModels.Components.Things
{
    public class DoorViewModel : BaseViewModel
    {
        string labelText = "Door is closed!";
        public string LabelText
        {
            get { return labelText; }
            set { SetProperty(ref labelText, value); }
        }
        bool isDoorOpen = false;
        public bool IsDoorOpen
        {
            get { return isDoorOpen; }
            set { SetProperty(ref isDoorOpen, value);
                if (IsDoorOpen)
                {
                    DoorColor = Xamarin.Forms.Color.SandyBrown;
                    LabelText = "Door is open!";
                    LabelColor = Xamarin.Forms.Color.Black;

                } else
                {
                    DoorColor = Xamarin.Forms.Color.SaddleBrown;
                    LabelText = "Door is closed!";
                    LabelColor = Xamarin.Forms.Color.White;
                }
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

            DeviceModel.StatesChanged += (sender, data) =>
            {
                if (data.ContainsKey("enabled"))
                {
                    if (data["enabled"] == "true")
                    {
                        OpenDoor();
                    }
                    else
                    {
                        CloseDoor();
                    }
                }
            };
        }

        public void ToggleDoor()
        {
            // TODO: Make call to "DeviceModel" object instead
            IsDoorOpen = !IsDoorOpen;
        }

        public void OpenDoor()
        {
            // TODO: Make call to "DeviceModel" object instead
            IsDoorOpen = true;
        }

        public void CloseDoor()
        {
            // TODO: Make call to "DeviceModel" object instead
            IsDoorOpen = false;
        }

        public void Knock()
        {
            IsKnocked = true;
        }

    }
}
