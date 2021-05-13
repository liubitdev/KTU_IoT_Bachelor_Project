using System;
using System.Threading.Tasks;
using Device_Emulator_App.HubDeviceAPI.Interfaces;
using Device_Emulator_App.HubDeviceAPI.Network;

namespace Device_Emulator_App.HubDeviceAPI
{
    public abstract class ControllerManager : IController
    {
        private static WebSockets websockets;

        virtual public async Task<int> ConnectToServer(Uri ipAddress)
        {
            int result = 0;
            try
            {
                websockets = new WebSockets(ipAddress);
                result = await websockets.EstablishConnection();
                //if (result == 1) WebSockets.DataReceived += ReceiveMessage;
            }
            catch
            {
                result = -1;
            }
            return result;
        }

        abstract public void ConfigureController(Models.Enums.EDeviceType type);

        public void Disconnect()
        {
            websockets.CloseConnection();
        }

        public async void SendMessage(string json)
        {
            await websockets.SendData(json);
        }

    }
}
