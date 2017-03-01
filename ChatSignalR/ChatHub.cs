using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace ChatSignalR
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        
        public void SendMessage(string message)
        {
            var msg = string.Format("{0}: {1}", Context.ConnectionId, message);

            Clients.All.newMessage(msg);

            //Same
            //Clients.Caller.newMessage(message);
            //Clients.Client(Context.ConnectionId).newMessage(message);

            //Same
            //Clients.Others
            //Clients.AllExcept(Context.ConnectionId)
        }

        public void JoinRoom(string room)
        {
            // Note: groups are not persisted on the server
            Groups.Add(Context.ConnectionId, room);
        }
        
        public void SendMessageToRoom (string room, string message)
        {
            var msg = string.Format("{0}: {1}", Context.ConnectionId, message);
            Clients.Group(room).newMessage(msg);
        }    

        public void SendMessageData(SendData data)
        {
            Clients.All.newData();
        }

        //public Task<int> SendDataAsync()
        //{
        //    //async work
        //}
    }

    public class SendData
    {
        public int ID { get; set; }
        public string Data { get; set; }
    }
}