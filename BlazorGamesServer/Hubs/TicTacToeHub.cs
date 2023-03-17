using Microsoft.AspNetCore.SignalR;

namespace BlazorGamesServer.Hubs
{
    public class TicTacToeHub : Hub
    {
        public async Task UpdateBoard()
        {
            await Clients.All.SendAsync("BoardChange");
        }
    }
}
