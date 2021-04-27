using System;
using Device_Emulator_App.ViewModels.Components.Things;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components.Things
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TvThing : ContentPage
    {
        public TvViewModel context = new TvViewModel();
        public TvThing()
        {
            InitializeComponent();

            BindingContext = context;
        }

        private void TvOnButton(object sender, EventArgs e)
        {
            context.TurnOnTv();
        }

        private void TvSwitchChannelButton(object sender, EventArgs e)
        {
            Random random = new Random();
            context.ChangeTvColor(Color.FromRgb(random.Next(255), random.Next(255), random.Next(255)));
            Console.WriteLine(context.TvOn);
        }

        private void TvOffButton(object sender, EventArgs e)
        {
            context.TurnOffTv();
        }

    }
}