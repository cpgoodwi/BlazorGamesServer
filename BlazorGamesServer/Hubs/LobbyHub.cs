using Microsoft.AspNetCore.SignalR;

namespace BlazorGamesServer.Hubs
{
    public class LobbyHub : SocialHub
    {
        public async Task UpdateLobby(string roomName)
        {
            await Clients.Group(roomName).SendAsync("LobbyChange", _rooms[roomName].Users);
        }
    }
}
