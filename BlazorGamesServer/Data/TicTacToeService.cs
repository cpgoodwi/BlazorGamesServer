namespace BlazorGamesServer.Data
{
    public class TicTacToeService
    {
        char[,] Board = new char[3, 3];

        public Task GetBoardAsync()
        {
            return Task.FromResult(Board);
        }
    }
}
