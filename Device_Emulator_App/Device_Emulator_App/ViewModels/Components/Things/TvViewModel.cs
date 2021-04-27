
using System;

namespace Device_Emulator_App.ViewModels.Components.Things
{
    public class TvViewModel : BaseViewModel
    {
        private bool tvOn;
        public bool TvOn
        {
            get { return tvOn; }
            set
            {
                SetProperty(ref tvOn, value);
                if (value)
                {
                    Random random = new Random();
                    TvColor = Xamarin.Forms.Color.FromRgb(random.Next(255), random.Next(255), random.Next(255));
                    TvText = "TV is turned ON!";
                    TvTextColor = Xamarin.Forms.Color.Black;
                } else
                {
                    TvColor = Xamarin.Forms.Color.Black;
                    TvText = "TV is turned OFF!";
                    TvTextColor = Xamarin.Forms.Color.White;
                }
            }
        }

        private Xamarin.Forms.Color tvColor;
        public Xamarin.Forms.Color TvColor
        {
            get
            {
                if (TvOn) return tvColor;
                return Xamarin.Forms.Color.Black;
            }
            set
            {
                SetProperty(ref tvColor, value);
            }
        }

        private string tvText;
        public string TvText
        {
            get
            {
                if (TvOn) return "TV is turned ON!";
                return "TV is turned OFF!";

            }
            set
            {
                SetProperty(ref tvText, value);
            }
        }

        private Xamarin.Forms.Color tvTextColor;
        public Xamarin.Forms.Color TvTextColor
        {
            get
            {
                if (TvOn) return tvTextColor;
                return Xamarin.Forms.Color.White;
            }
            set
            {
                SetProperty(ref tvTextColor, value);
            }
        }

        public TvViewModel()
        {
            TvOn = false;
            TvColor = Xamarin.Forms.Color.Black;
            TvText = "TV is turned OFF!";
            TvTextColor = Xamarin.Forms.Color.White;
        }

        public void ChangeTvColor(Xamarin.Forms.Color color)
        {
            TvColor = color;
        }

        public void TurnOffTv()
        {
            TvOn = false;
        }

        public void TurnOnTv()
        {
            TvOn = true;
        }

    }
}
