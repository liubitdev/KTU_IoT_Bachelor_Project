using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Device_Emulator_App.ViewModels.Components.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Device_Emulator_App.Views.Components.Controllers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MailboxController : BasePage
    {
        public MailboxViewModel context = new MailboxViewModel();
        public MailboxController()
        {
            InitializeComponent();

            BindingContext = context;
        }

        public void PutInParcel(object sender, EventArgs e)
        {
            context.AddParcel();
        }

    }
}