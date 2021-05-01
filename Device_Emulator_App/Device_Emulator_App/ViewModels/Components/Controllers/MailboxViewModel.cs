using System;
using System.Collections.Generic;
using System.Text;

namespace Device_Emulator_App.ViewModels.Components.Controllers
{
    public class MailboxViewModel : BaseViewModel
    {
        string labelText = "Mailbox is Empty!";
        public string LabelText
        {
            get { return labelText; }
            set { SetProperty(ref labelText, value); }
        }

        bool isMailboxFull;
        public bool IsMailboxFull
        {
            get { return isMailboxFull; }
            set
            {
                SetProperty(ref isMailboxFull, value);
                if (IsMailboxFull)
                {
                    ViewColor = Xamarin.Forms.Color.White;
                    LabelText = "Mailbox is Filled!";
                    LabelColor = Xamarin.Forms.Color.Black;

                }
                else
                {
                    ViewColor = Xamarin.Forms.Color.Black;
                    LabelText = "Mailbox is Empty!";
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

        private Xamarin.Forms.Color viewColor;
        public Xamarin.Forms.Color ViewColor
        {
            get { return viewColor; }
            set { SetProperty(ref viewColor, value); }
        }

        public MailboxViewModel()
        {
            IsMailboxFull = false;

        }

        public void AddParcel()
        {
            IsMailboxFull = true;
        }

        public void RemoveParcel()
        {
            IsMailboxFull = false;
        }

    }
}
