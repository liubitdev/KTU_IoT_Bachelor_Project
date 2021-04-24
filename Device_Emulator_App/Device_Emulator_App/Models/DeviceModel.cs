using System.Collections.Generic;
using Device_Emulator_App.Models.Enums;
using Device_Emulator_App.Models.Network;
using Newtonsoft.Json;

namespace Device_Emulator_App.Models
{
    public static class DeviceModel
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static EDeviceNetworkState NetworkState { get; set; }
        public static EDeviceType Type { get; set; }
        public static EDeviceGroup Group { get; set; }
        public static WebSockets WebSocket { get; set; }
        public static Dictionary<string, string> States { get; set; }

        public static void Configure(string name, EDeviceType type, EDeviceGroup group)
        {
            Name = name;
            Type = type;
            Group = group;
            WebSocket = new WebSockets();
            States = new Dictionary<string, string>();
        }

        public static void Create()
        {
            WebSocket.EstablishConnection();
            // TODO: Send info about this device to HUB
            WebSockets.DataReceived += (s, o) =>
            {
                Receive(o.ToString());
            };
        }

        private static void Receive(string json)
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            // TODO: Add json parsing and handling
            foreach (string key in dict.Keys)
            {
                if (States.ContainsKey(key))
                { // Update the value
                    States[key] = dict[key];
                } else
                { // If not - add the new key & value
                    States.Add(key, dict[key]);
                }
            }
        }

    }
}
