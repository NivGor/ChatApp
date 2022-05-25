using ChatAppWebAPI.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatWebAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message, string contactId, string username)
        {
            object[] args = new object[3];
            args[0] = message;
            args[1] = contactId;
            args[2] = username;
            await Clients.All.SendAsync("ReceiveMessage", args);
        }
    }
}
