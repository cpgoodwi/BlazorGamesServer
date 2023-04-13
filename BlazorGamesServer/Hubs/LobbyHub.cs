using BlazorGamesServer.Data.Social;
using Microsoft.AspNetCore.SignalR;

namespace BlazorGamesServer.Hubs
{
    public class LobbyHub : SocialHub
    {
        public async Task UpdateLobby(string roomName)
        {
            if (_rooms.TryGetValue(roomName, out var currentRoom))
            {
                //await Clients.Group(roomName).SendAsync("LobbyChange", currentRoom.Users);
                await Clients.Group(roomName).SendAsync("LobbyChange");
            }
            //await Clients.Group(roomName).SendAsync("LobbyChange");
        }
    }
}
