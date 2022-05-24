using ChatAppWebAPI.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatWebAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message, String userId)
        {
            await Clients.User(userId).SendAsync("ReceiveMessage", message);
        }
    }
}
