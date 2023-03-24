using BlazorGamesServer.Data;
using BlazorGamesServer.Data.Social;
using Microsoft.AspNetCore.SignalR;

namespace BlazorGamesServer.Hubs
{
    public class SocialHub : Hub
    {
        // this list of rooms is shared by all hubs, so I'm putting the dictionary into a higher class to be inherited
        protected readonly static Dictionary<string, Room> _rooms = new();

        public async Task JoinRoom(User user, string roomName)
        {
            if (!_rooms.TryGetValue(roomName, out var currentRoom))
            {
                currentRoom = new Room(roomName);
                _rooms[roomName] = currentRoom;
            }
            currentRoom.Users.Add(user);

            await Clients.Group(roomName).SendAsync("UserJoined", user);

            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public async Task LeaveRoom(User user, string roomName)
        {
            _rooms[roomName].Users.Remove(user);
            await Clients.Group(roomName).SendAsync("UserLeft", user);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
