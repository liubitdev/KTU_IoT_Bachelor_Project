using System.Collections;
using System.Collections.ObjectModel;
using Device_Emulator_App.Models;
using Device_Emulator_App.Views;
using Newtonsoft.Json;

namespace Device_Emulator_App.ViewModels.Components.Things
{
    public class MessageReceiverViewModel : BaseViewModel
    {
        private ObservableCollection<string> messageLog;
        public ObservableCollection<string> MessageLog
        {
            get { return messageLog; }
            set { SetProperty(ref messageLog, value); }
        }

        public MessageReceiverViewModel()
        {
            MessageLog = new ObservableCollection<string>();

            ThingsPage.deviceModel.MessageReceived += AddMessage;
        }

        public void ClearLog()
        {
            MessageLog.Clear();
        }

        public void AddMessage(object sender, object data)
        {
            if (data.GetType() != typeof(string))
                messageLog.Add(JsonConvert.SerializeObject(data));
            else
            {
                string message = data.ToString()
                    .Replace("\\", "")
                    .Replace("\"", "")
                    .Replace("{", "")
                    .Replace("}", "");
                messageLog.Add(message);
            }
        }

    }
}
