using Device_Emulator_App.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Device_Emulator_App.ViewModels.Components.Controllers
{
    public class ButtonViewModel : BaseViewModel
    {
        public void SendMessage()
        {
            // TODO: Change into more specific activation messsage
            ControllersPage.deviceModel.SendMessage("{\"message\":\"Hello!\"}");
        }

    }
}
