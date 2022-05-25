using ChatAppWebAPI.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatWebAPI.Hubs
{
    public class ChatHub : Hub
    {
        static Dictionary<string,string> connections = new Dictionary<string,string>();
         public void AddConnection(string username)
        {
            connections[username] = Context.ConnectionId;
        }
        public Boolean Authenticate(string username) 
        { 
            if(connections.ContainsKey(username) && connections[username] == Context.ConnectionId)
            {
                return true;
            }
            return false;
        }
        public async Task SendMessage(Message message, string username)
        {
            //if (Authenticate(username) == false)
            //{
            //    return;
            //}
            //object[] args = new object[2];
            //args[0] = message;
            //args[1] = username;
            //args[2] = username;
            await Clients.Client(connections[username]).SendAsync("ReceiveMessage", message);
        }
    }
}
