namespace BlazorGamesServer.Data
{
    public class TicTacToeService
    {
        private readonly TicTacToe.Tile[,] Board = new TicTacToe.Tile[3, 3] {
            { new TicTacToe.Tile(), new TicTacToe.Tile(), new TicTacToe.Tile() },
            { new TicTacToe.Tile(), new TicTacToe.Tile(), new TicTacToe.Tile() },
            { new TicTacToe.Tile(), new TicTacToe.Tile(), new TicTacToe.Tile() },
        };

        private bool IsXMove = true;

        public Task<TicTacToe.Tile[,]> GetBoardAsync()
        {
            return Task.FromResult(Board);
        }

        public Task<bool> GetTurnAsync()
        {
            return Task.FromResult(IsXMove);
        }

        public Task ResetAsync()
        {
            for (int x = 0; x < Board.GetLength(0); x++)
            {
                for (int y = 0; y < Board.GetLength(1); y++)
                {
                    Board[x, y] = new TicTacToe.Tile();
                }
            }

            IsXMove = true;

            return Task.CompletedTask;
        }

        public Task MakeMoveAsync(int x, int y)
        {
            Board[x, y].SetValue(IsXMove ? 'X' : 'O');

            IsXMove = !IsXMove;

            return Task.CompletedTask;
        }
    }
}
