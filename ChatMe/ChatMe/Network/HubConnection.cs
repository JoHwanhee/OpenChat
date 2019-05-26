using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ControlzEx.Standard;

namespace ChatMe.Network
{
    public class HubConnection
    {
        public static HubProxy Proxy = null;

        public static HubProxy Create(string url)
        {
            if (Proxy == null)
            {
                return new HubProxy(url);
            }

            return Proxy;
        }
    }
}
