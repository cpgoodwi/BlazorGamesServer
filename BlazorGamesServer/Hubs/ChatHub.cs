using Microsoft.AspNetCore.SignalR;
using BlazorGamesServer.Data;

namespace BlazorGamesServer.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(User user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
