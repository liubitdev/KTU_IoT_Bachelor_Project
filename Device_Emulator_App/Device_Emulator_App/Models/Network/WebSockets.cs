using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Device_Emulator_App.Models.Network
{
    class WebSockets : IDisposable
    {
        public static event EventHandler<string> DataReceived = null;

        private static ClientWebSocket ws = null;
        private static System.Timers.Timer socketTimer = new System.Timers.Timer(5000);
        private static string keepAliveMessage = "{\"message\":\"online\"}";

        public WebSockets()
        {
            socketTimer.Elapsed += SocketTimerElapsed;
        }

        public async void EstablishConnection()
        {
            if (ws == null)
            {
                ws = new ClientWebSocket();
            }
            else if (ws.State == WebSocketState.Open)
            {
                // Return if the socket is already open and running
                return;
            }
            await ws.ConnectAsync(new Uri("ws://10.0.2.2:8000/"), CancellationToken.None);
            socketTimer.Start();
            ListenToSocket();
        }

        public async Task SendData(string jsonData)
        {
            var encoded = Encoding.UTF8.GetBytes(jsonData);
            var buffer = new ArraySegment<Byte>(encoded, 0, encoded.Length);
            await ws.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async void ListenToSocket()
        {
            if (ws == null) return;

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

        public async void CloseConnection()
        {
            if(ws.State != WebSocketState.Closed)
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
                EstablishConnection();
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
