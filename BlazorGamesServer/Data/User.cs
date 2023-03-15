namespace BlazorGamesServer.Data
{
    public enum UserType
    {
        Guest,
        Player
    }

    public class User
    {
        public string? Name { get; set; }
        public UserType? Type { get; set; }
        public Guid? Id { get; set; }

        public User(string? name, UserType? type)
        {
            Name = name;
            Type = type;
            Id = Guid.NewGuid();
        }

    }
}
