using System;
using System.Collections.Generic;
using System.Text;
using Device_Emulator_App.Models;

namespace Device_Emulator_App.ViewModels.Components.Things
{
    public class LightViewModel : BaseViewModel
    {
        string labelText = "Light is turned OFF!";
        public string LabelText
        {
            get { return labelText; }
            set { SetProperty(ref labelText, value); }
        }
        bool isLightOn = false;
        public bool IsLightOn
        {
            get { return isLightOn; }
            set
            {
                SetProperty(ref isLightOn, value);
                if (IsLightOn)
                {
                    LightColor = Xamarin.Forms.Color.White;
                    LabelText = "Light is turned ON!";
                    LabelColor = Xamarin.Forms.Color.Black;

                }
                else
                {
                    LightColor = Xamarin.Forms.Color.Black;
                    LabelText = "Light is turned OFF!";
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

        private Xamarin.Forms.Color lightColor;
        public Xamarin.Forms.Color LightColor
        {
            get { return lightColor; }
            set { SetProperty(ref lightColor, value); }
        }

        public LightViewModel()
        {
            TurnOffLight();

            DeviceModel.StatesChanged += (sender, data) =>
            {
                if (data.ContainsKey("enabled"))
                {
                    if(data["enabled"] == "true")
                    {
                        TurnOnLight();
                    } else
                    {
                        TurnOffLight();
                    }
                }
            };
        }

        public void ToggleLight()
        {
            IsLightOn = !IsLightOn;
        }

        public void TurnOnLight()
        {
            IsLightOn = true;
        }

        public void TurnOffLight()
        {
            IsLightOn = false;
        }
    }
}
