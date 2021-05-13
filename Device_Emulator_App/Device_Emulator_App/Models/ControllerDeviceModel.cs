using System;
using System.Collections.Generic;
using System.Text;
using Device_Emulator_App.HubDeviceAPI;
using Device_Emulator_App.HubDeviceAPI.Interfaces;
using Device_Emulator_App.Models.Enums;
using Newtonsoft.Json;

namespace Device_Emulator_App.Models
{
    public class ControllerDeviceModel : ControllerManager, IDevice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public EDeviceNetworkState State { get; set; }
        public EDeviceType Type { get; set; }

        private List<string> ActionList;
        //public event EventHandler<Dictionary<string, string>> StateChanged = null;
        public ISubscribable DeviceObject = null;

        public override void ConfigureController(EDeviceType type)
        {
            Name = "GENERATE NAME HERE";
            Type = type;
            State = EDeviceNetworkState.UNDEFINED;
        }

        public async void Connect(string ipAddress)
        {
            int result = await ConnectToServer(ipAddress);
            if (result == 1) // Connected to server successfully
            {
                Send("SEND DEVICE INFO HERE");
                State = EDeviceNetworkState.ONLINE;
            }
            else // Problem occured while trying to connect to server
            {
                Console.WriteLine("Problem while connecting to server");
                State = EDeviceNetworkState.OFFLINE;
            }
        }

        public void SetActions(List<string> actions)
        {
            ActionList = actions;
        }

        public void Send(string json)
        {
            SendMessage(json);
        }


    }
}
