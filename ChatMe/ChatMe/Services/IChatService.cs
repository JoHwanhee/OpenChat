using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatMe.Models;

namespace ChatMe.Services
{
    public interface IChatService
    {
        event Action<string> ParticipantLoggedIn;
        event Action<string> ParticipantLoggedOut;
        event Action<string> ParticipantDisconnected;
        event Action<string> ParticipantReconnected;
        event Action ConnectionReconnecting;
        event Action ConnectionReconnected;
        event Action ConnectionClosed;
        event Action<string, string, MessageType> NewTextMessage;
        event Action<string, byte[], MessageType> NewImageMessage;
        event Action<string> ParticipantTyping;

        void ConnectAsync();
        void LoginAsync(string name, byte[] photo);
        void LogoutAsync();

        void SendBroadcastMessageAsync(string msg);
        void SendBroadcastMessageAsync(byte[] img);
        void SendUnicastMessageAsync(string recepient, string msg);
        void SendUnicastMessageAsync(string recepient, byte[] img);
        void TypingAsync(string recepient);
    }
}