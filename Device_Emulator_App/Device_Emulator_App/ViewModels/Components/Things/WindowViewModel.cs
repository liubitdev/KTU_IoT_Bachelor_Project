using Device_Emulator_App.Models;

namespace Device_Emulator_App.ViewModels.Components.Things
{
    class WindowViewModel : BaseViewModel
    {
        string labelText = "Window is closed!";
        public string LabelText
        {
            get { return labelText; }
            set { SetProperty(ref labelText, value); }
        }
        bool isWindowOpen = false;
        public bool IsWindowOpen
        {
            get { return isWindowOpen; }
            set
            {
                SetProperty(ref isWindowOpen, value);
                if (isBroken)
                {
                    WindowColor = Xamarin.Forms.Color.Gray;
                    LabelText = "Window is Broken!";
                    LabelColor = Xamarin.Forms.Color.Black;
                }
                else if (IsWindowOpen)
                {
                    WindowColor = Xamarin.Forms.Color.White;
                    LabelText = "Window is Open!";
                    LabelColor = Xamarin.Forms.Color.Black;

                }
                else
                {
                    WindowColor = Xamarin.Forms.Color.Black;
                    LabelText = "Window is Closed!";
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

        private Xamarin.Forms.Color windowColor;
        public Xamarin.Forms.Color WindowColor
        {
            get { return windowColor; }
            set { SetProperty(ref windowColor, value); }
        }

        private bool isBroken;
        public bool IsBroken
        {
            get { return isBroken; }
            set { SetProperty(ref isBroken, value); }
        }

        public WindowViewModel()
        {

            CloseWindow();

            DeviceModel.StatesChanged += (sender, data) =>
            {
                if (data.ContainsKey("enabled"))
                {
                    if (data["enabled"] == "true")
                    {
                        OpenWindow();
                    }
                    else
                    {
                        CloseWindow();
                    }
                }
            };
        }

        public void ToggleWindow()
        {
            // TODO: Make call to "DeviceModel" object instead
            IsWindowOpen = !IsWindowOpen;

        }

        public void OpenWindow()
        {
            // TODO: Make call to "DeviceModel" object instead
            IsWindowOpen = true;
        }

        public void CloseWindow()
        {
            // TODO: Make call to "DeviceModel" object instead
            IsWindowOpen = false;
        }

        public void BreakWindow()
        {
            IsBroken = true;
            IsWindowOpen = true;
        }

        public void FixWindow()
        {
            IsBroken = false;
            IsWindowOpen = false;
        }

    }
}
