using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Device_Emulator_App.HubDeviceAPI.Network
{
    public class WebSockets : IDisposable
    {
        // Event which fires every time a new packet is received
        public static event EventHandler<string> DataReceived = null;
        // Server's IP address which client is connecting to
        public static Uri IP { get; set; } = new Uri("ws://10.0.2.2:8000/");
        // WebSocket client object
        private static ClientWebSocket ws = null;
        // Timer for client to send an update/keep-alive message
        private static System.Timers.Timer socketTimer = new System.Timers.Timer(5000);
        // Message which will be repeatedly sent to the server to ensure that the connection is alive
        private static string keepAliveMessage = "{\"message\":\"online\"}";

        public WebSockets()
        {
            socketTimer.Elapsed += SocketTimerElapsed;
        }

        public WebSockets(Uri ipAddress) : this()
        {
            IP = ipAddress;
        }

        public async Task<int> EstablishConnection()
        {
            if (ws == null)
            {
                ws = new ClientWebSocket();
            }
            if (ws.State == WebSocketState.Open)
            {
                DataReceived = null;
                // Return if the socket is already open and running
                return 1;
            }
            if (ws.State == WebSocketState.None)
            {
                await ws.ConnectAsync(IP, CancellationToken.None);
                DataReceived = null;
                socketTimer.Start();
                ListenToSocket();
                return 1;
            }
            return -1;
        }

        public async Task SendData(string jsonData)
        {
            if (ws == null)
            {
                HandleOfflineRequest();
                return;
            }
            if (ws.State != WebSocketState.Open)
            {
                HandleOfflineRequest();
                return;
            }

            var encoded = Encoding.UTF8.GetBytes(jsonData);
            var buffer = new ArraySegment<Byte>(encoded, 0, encoded.Length);
            await ws.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async void ListenToSocket()
        {
            if (ws == null)
            {
                HandleOfflineRequest();
                return;
            }

            var readBuffer = new ArraySegment<byte>(new Byte[8192]);
            while (ws.State == WebSocketState.Open) // Keep listening to the socket while its open
            {
                WebSocketReceiveResult result = null;
                try // If already listening to socket
                {
                    result = await ws.ReceiveAsync(readBuffer, CancellationToken.None);
                }
                catch (Exception e)
                {
                    return;
                }
                var str = Encoding.Default.GetString(readBuffer.Array, readBuffer.Offset, result.Count);
                if (str != null)
                {
                    DataReceived?.Invoke(this, str);
                }
            }
        }

        public void SetKeepAliveMessage(string message)
        {
            if (message == null) keepAliveMessage = "{\"message\":\"online\"}";
            keepAliveMessage = message;
        }

        private void HandleOfflineRequest()
        {
            DataReceived?.Invoke(this, "No connection to server.");
            return;
        }

        public async void CloseConnection()
        {
            if (ws.State != WebSocketState.Closed)
            {
                await ws.CloseAsync(WebSocketCloseStatus.Empty, String.Empty, CancellationToken.None);
            }
            ws.Dispose();
            socketTimer.Stop();
        }

        private async void SocketTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (ws == null)
            {
                // If the client is not connected to the HUB yet
                await EstablishConnection();
            }
            else
            {
                // Keep alive the connection with HUB
                await SendData(keepAliveMessage);
            }
        }

        public void Dispose()
        {
            if (socketTimer != null)
            {
                socketTimer.Dispose();
                socketTimer = null;
            }

            if (ws != null)
            {
                ws.Dispose();
                ws = null;
            }
        }
    }
}
