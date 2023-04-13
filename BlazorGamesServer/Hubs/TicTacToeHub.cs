using Microsoft.AspNetCore.SignalR;

namespace BlazorGamesServer.Hubs
{
    public class TicTacToeHub : SocialHub
    {
        public async Task UpdateBoard()
        {
            await Clients.All.SendAsync("BoardChange");
        }
    }
}
