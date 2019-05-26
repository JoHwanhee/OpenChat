using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatMe.Models;
using ChatMe.Network;

namespace ChatMe.Services
{
    public class ChatService : IChatService
    {
        public event Action<string> ParticipantLoggedIn;
        public event Action<string> ParticipantLoggedOut;
        public event Action<string> ParticipantDisconnected;
        public event Action<string> ParticipantReconnected;
        public event Action<string, string, MessageType> NewTextMessage;
        public event Action<string, byte[], MessageType> NewImageMessage;
        public event Action<string> ParticipantTyping;
        public event Action ConnectionReconnecting;
        public event Action ConnectionReconnected;
        public event Action ConnectionClosed;

        private HubProxy _proxy;

        public ChatService(string url)
        {
            _proxy = HubConnection.Create(url);
        }

        public void ConnectAsync()
        {
            _proxy.On("ParticipantLoggedIn", x => ParticipantLoggedIn?.Invoke((string)x));
            _proxy.On("ParticipantLoggedOut", x => ParticipantLoggedOut?.Invoke((string)x));
            _proxy.On("ParticipantDisconnected", x => ParticipantDisconnected?.Invoke((string)x));
            _proxy.On("ParticipantReconnected", x => ParticipantReconnected?.Invoke((string)x));
            //_proxy.On("NewTextMessage", x=> NewTextMessage?.Invoke((string)x));
            //_proxy.On("NewImageMessage", x=> NewImageMessage?.Invoke((string)x));
            _proxy.On("ParticipantTyping", x => ParticipantTyping?.Invoke((string)x));
            _proxy.Start();
        }

        public void LoginAsync(string name, byte[] photo)
        {
            _proxy.Invoke("Login", photo);
        }

        public void LogoutAsync()
        {
            _proxy.Invoke("Logout", "");
        }

        public void SendBroadcastMessageAsync(string msg)
        {
            _proxy.Invoke("SendBroadcastMessage", msg);
        }

        public void SendBroadcastMessageAsync(byte[] img)
        {
            _proxy.Invoke("SendBroadcastMessage", img);
        }

        public void TypingAsync(string recepient)
        {
            _proxy.Invoke("Typing", recepient);
        }

        public void SendUnicastMessageAsync(string recepient, string msg)
        {
            throw new NotImplementedException();
        }

        public void SendUnicastMessageAsync(string recepient, byte[] img)
        {
            throw new NotImplementedException();
        }

    }
}
