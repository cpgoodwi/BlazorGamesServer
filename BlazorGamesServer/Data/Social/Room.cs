namespace BlazorGamesServer.Data.Social
{
    public class Room
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Message> Messages { get; set; }

        public Room(string name)
        {
            Name = name;
            Users = new List<User>();
            Messages = new List<Message>();
        }
    }
}
