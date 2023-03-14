namespace BlazorGamesServer.Data.TicTacToe
{
    public class Tile
    {
        public char Value = ' ';
        public bool IsMutable = true;

        public void SetValue(char value) { Value = value; IsMutable = false; }
    }
}
