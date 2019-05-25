using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatMe.ViewModels;

namespace ChatMe.Models
{
    public class Participant 
    {
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public bool IsLoggedIn { get; set; } = true;
        public bool HasSentNewMessage { get; set; }
        public bool IsTyping { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }
    }
}
