using System;
using System.Threading.Tasks;
using Device_Emulator_App.HubDeviceAPI.Interfaces;
using Device_Emulator_App.HubDeviceAPI.Network;

namespace Device_Emulator_App.HubDeviceAPI
{
    public abstract class ControllerManager : IController
    {
        private WebSockets websockets;

        virtual public async Task<int> ConnectToServer(string ipAddress)
        {
            websockets = new WebSockets(new Uri(ipAddress));
            return await websockets.EstablishConnection();
        }

        abstract public void ConfigureController(Models.Enums.EDeviceType type);

        public async void SendMessage(string json)
        {
            await websockets.SendData(json);
        }

        public void Disconnect()
        {
            websockets.CloseConnection();
        }

    }
}
