using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Device_Emulator_App.HubDeviceAPI.Interfaces;
using Device_Emulator_App.HubDeviceAPI.Network;

namespace Device_Emulator_App.HubDeviceAPI
{
    abstract public class ThingManager : IThing
    {
        private static WebSockets websockets;

        virtual public async Task<int> ConnectToServer(Uri ipAddress)
        {
            int result = 0;
            try
            {
                websockets = new WebSockets(ipAddress);
                result = await websockets.EstablishConnection();
                if (result == 1) WebSockets.DataReceived += ReceiveMessage;
            } catch
            {
                result = -1;
            }
            return result;
        }

        abstract public void ConfigureThing(Models.Enums.EDeviceType type);

        public void Disconnect()
        {
            websockets.CloseConnection();
        }

        public async void NotifyState(string json)
        {
            await websockets.SendData(json);
        }

        public abstract void ReceiveMessage(object sender, string message);

    }
}
