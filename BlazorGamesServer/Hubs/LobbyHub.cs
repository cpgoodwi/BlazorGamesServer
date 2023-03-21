using Microsoft.AspNetCore.SignalR;

namespace BlazorGamesServer.Hubs
{
    public class LobbyHub : Hub
    {
        public async Task UpdateLobby()
        {
            await Clients.All.SendAsync("LobbyChange");
        }
    }
}
