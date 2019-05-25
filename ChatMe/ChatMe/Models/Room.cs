using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMe.Models
{
    public class Room
    {
        public string Seq { get; set; }
        public List<Participant> Participants { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }
    }
}
