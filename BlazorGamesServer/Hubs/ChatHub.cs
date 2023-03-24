using Microsoft.AspNetCore.SignalR;
using BlazorGamesServer.Data;
using BlazorGamesServer.Data.Social;
using System.Security.Claims;

namespace BlazorGamesServer.Hubs
{
    public class ChatHub : SocialHub
    {
        //private readonly static Dictionary<string, Room> _rooms = new();

        public async Task SendMessage(Message message, string roomName)
        {
            if (_rooms.TryGetValue(roomName,out var currentRoom))
            {
                currentRoom.Messages.Add(message);
            }

            await Clients.Group(roomName).SendAsync("ReceiveMessage", message);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // TODO: Does this really need to be here?

            await base.OnDisconnectedAsync(exception);
        }
    }
}
