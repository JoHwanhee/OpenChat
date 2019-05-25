using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatMe.Models;

namespace ChatMe.Services
{
    public class ChatService : IChatService
    {
        public event Action<User> ParticipantLoggedIn;
        public event Action<string> ParticipantLoggedOut;
        public event Action<string> ParticipantDisconnected;
        public event Action<string> ParticipantReconnected;
        public event Action ConnectionReconnecting;
        public event Action ConnectionReconnected;
        public event Action ConnectionClosed;
        public event Action<string, string, MessageType> NewTextMessage;
        public event Action<string, byte[], MessageType> NewImageMessage;
        public event Action<string> ParticipantTyping;


        public Task ConnectAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> LoginAsync(string name, byte[] photo)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task SendBroadcastMessageAsync(string msg)
        {
            throw new NotImplementedException();
        }

        public Task SendBroadcastMessageAsync(byte[] img)
        {
            throw new NotImplementedException();
        }

        public Task SendUnicastMessageAsync(string recepient, string msg)
        {
            throw new NotImplementedException();
        }

        public Task SendUnicastMessageAsync(string recepient, byte[] img)
        {
            throw new NotImplementedException();
        }

        public Task TypingAsync(string recepient)
        {
            throw new NotImplementedException();
        }
    }
}
