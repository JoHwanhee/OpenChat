using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMe.Models
{
    public class ChatMessage
    {
        public string Author { get; set; }
        public string Message { get; set; }
        public string Picture { get; set; }
        public bool IsOriginNative { get; set; }
        public DateTime Time { get; set; }

    }
}
