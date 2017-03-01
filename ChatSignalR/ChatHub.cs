using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatSignalR
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        
        public void SendMessage(string message)
        {
            Clients.All.hello();
        }
    }
}