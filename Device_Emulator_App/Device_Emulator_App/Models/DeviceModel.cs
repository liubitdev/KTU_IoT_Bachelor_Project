using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Device_Emulator_App.HubDeviceAPI.Interfaces;
using Device_Emulator_App.Models.Enums;
using Newtonsoft.Json;

namespace Device_Emulator_App.Models
{
    public static class DeviceModel
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static EDeviceNetworkState NetworkState { get; set; }
        public static EDeviceType Type { get; set; }
        //public static WebSockets WebSocket { get; set; }
        public static Dictionary<string, string> States { get; set; }
        public static event EventHandler<Dictionary<string, string>> StatesChanged = null;
        public static ISubscribable DeviceObject = null;

        public static void Configure(string name, EDeviceType type)
        {
            Name = name;
            Type = type;
            //if(WebSocket == null) WebSocket = new WebSockets();
            States = new Dictionary<string, string>();
            StatesChanged = null;
        }

        public static void Configure(Uri ip, string name, EDeviceType type)
        {
            Name = name;
            Type = type;
            //if (WebSocket == null) WebSocket = new WebSockets(ip);
            States = new Dictionary<string, string>();
            StatesChanged = null;
        }

        public static void Configure(ISubscribable deviceObject)
        {
            DeviceObject = deviceObject;
            deviceObject.StatesChanged += Update;
        }

        public async static Task Create()
        {
            //await WebSocket.EstablishConnection();
            // TODO: Send info about this device to HUB
            //WebSockets.DataReceived += (s, o) =>
            //{
                //Receive(o.ToString());
            //};
        }

        public async static void Update(object sender, object json)
        {
            // TODO: Send updated info to server
            // v Send JSON v
            //await WebSocket.SendData((string)json);
        }

        public static void ClearSubscriptions()
        {
            StatesChanged = null;
        }

        private static void Receive(string json)
        {
            // We don't want the 'StatesChanged' event to fire if received message from HUB contains no new information
            bool changed = false;
            var dict = new Dictionary<string, string>();

            try
            {
                // Deserialize the received Json for better handling
                dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            catch (Exception e)
            {
                dict.Add("undefined", json);
            }

            foreach (string key in dict.Keys)
            {
                if (States.ContainsKey(key))
                {
                    if (States[key] != dict[key])
                    {
                        // Update the value
                        States[key] = dict[key];
                        changed = true;
                    }
                }
                else
                { // If not - add the new key & value
                    States.Add(key, dict[key]);
                    changed = true;
                }
            }
            //if (changed)
            //{
            //StatesChanged?.Invoke(WebSockets.IP, States);
            //}
        }

        public static void Disconnect()
        {
            NetworkState = EDeviceNetworkState.OFFLINE;
            //WebSocket.CloseConnection();
        }

    }
}
