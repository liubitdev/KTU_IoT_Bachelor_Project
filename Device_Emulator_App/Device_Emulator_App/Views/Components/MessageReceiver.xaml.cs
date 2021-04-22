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
    public partial class MessageReceiver : ContentView
    {
        public string DisplayedMessage { get; } = "Received Message Goes Here!"; // implement INotifyPropertyChanged to change it

        public MessageReceiver()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}