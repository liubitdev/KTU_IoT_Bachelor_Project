using System.Collections;
using System.Collections.ObjectModel;
using Device_Emulator_App.Models;
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

            DeviceModel.StatesChanged += AddMessage;
        }

        public void ClearLog()
        {
            MessageLog.Clear();
        }

        public void AddMessage(object sender, object data)
        {
            MessageLog.Add(JsonConvert.SerializeObject(data));
        }

    }
}
