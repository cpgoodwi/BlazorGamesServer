﻿namespace BlazorGamesServer.Data
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
        public Guid Id { get; }

        public User(string? name, UserType? type)
        {
            Name = name;
            Type = type;
            Id = Guid.NewGuid();
        }

        public void SetName(string? name)
        {
            Name = name;
            Type = UserType.Player;
        }
    }
}
