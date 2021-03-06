using System;
using System.Collections.Generic;
using System.Text;
using Device_Emulator_App.HubDeviceAPI;
using Device_Emulator_App.HubDeviceAPI.Interfaces;
using Device_Emulator_App.Models.Enums;
using Device_Emulator_App.Models.Utils;

namespace Device_Emulator_App.Models
{
    public class ControllerDeviceModel : ControllerManager, IDevice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public EDeviceNetworkState State { get; set; }
        public EDeviceType Type { get; set; }
        public List<string> ActionList { get; set; }

        //public event EventHandler<string> MessageReceived = null;

        public ControllerDeviceModel()
        {
            Name = null;
            Password = null;
            Type = EDeviceType.NONE;
            State = EDeviceNetworkState.UNDEFINED;
        }

        public override void ConfigureController(EDeviceType type)
        {
            Name = type.ToString().ToLower() + "-" + RandomGenerator.GenerateRandomString(8);
            Type = type;
            State = EDeviceNetworkState.UNDEFINED;
        }

        public void SetActions(List<string> actions)
        {
            ActionList = actions;
        }

    }
}
