using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChatMe.Utils;

namespace ChatMe.Network
{
    public class HubProxy
    {
        private ClientWebSocket socket;
        private CancellationTokenSource cancellationToken;
        private Dictionary<string, Action<object>> actions = new Dictionary<string, Action<object>>();
        public bool IsConnected { get; private set; }= false;

        private string url;

        public HubProxy(string url)
        {
            this.url = url;
        }

        public async void Start()
        {
            socket = new ClientWebSocket();
            Uri uri = new Uri(url);
            cancellationToken = new CancellationTokenSource();
            await socket.ConnectAsync(uri, cancellationToken.Token);
            IsConnected = true;

            await Task.Factory.StartNew(ReceivedTask, cancellationToken.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        private async void ReceivedTask()
        {
            var bufferBytes = new byte[2048];
            var buffer = new ArraySegment<byte>(bufferBytes);
            while (IsConnected)
            {
                WebSocketReceiveResult rcvResult = await socket.ReceiveAsync(buffer, cancellationToken.Token);

                byte[] readBytes = buffer.Skip(buffer.Offset)
                                         .Take(rcvResult.Count)
                                         .ToArray();

                string firstLine = "";
                using (var stream = new StreamReader(new MemoryStream(readBytes)))
                {
                    firstLine = await stream.ReadLineAsync();
                }

                var method = firstLine.Replace("\r\n", "");
                actions[method].Invoke(readBytes.Skip(firstLine.Length));
            }
        }

        public void On(string eventName, Action<object> action)
        {
            actions[eventName] = action;
        }

        public async void Invoke(string method, byte[] data)
        {
            var methodBytes = Encoding.UTF8.GetBytes(method + "\r\n");
            var sendData = ByteArrayExtension.Combine(methodBytes, data);
            var sendBuffer = new ArraySegment<byte>(sendData);
            await socket.SendAsync(sendBuffer, WebSocketMessageType.Binary, endOfMessage: true, cancellationToken: cancellationToken.Token);
        }

        public async void Invoke(string method, string message)
        {
            var sendMessage = $"{method}\r\n{message}";
            byte[] sendBytes = Encoding.UTF8.GetBytes(sendMessage);
            var sendBuffer = new ArraySegment<byte>(sendBytes);
            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, endOfMessage: true, cancellationToken: cancellationToken.Token);
        }

        public void Disconnect()
        {
            cancellationToken.Cancel();
            IsConnected = false;
        }
    }
}
