using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AGAServerDev.Hubs
{
    public class NotifyHub : Hub
    {
        public void SendMessage(string name, string message)
        {
            Clients.All.NotifyPush(name, message);
        }
    }
}