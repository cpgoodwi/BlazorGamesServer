using Microsoft.AspNetCore.SignalR;
using BlazorGamesServer.Data;
using BlazorGamesServer.Data.Social;
using System.Security.Claims;

namespace BlazorGamesServer.Hubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, Room> _rooms = new Dictionary<string, Room>();

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

        public async Task SendMessage(Message message, string roomName)
        {
            if (_rooms.TryGetValue(roomName,out var currentRoom))
            {
                currentRoom.Messages.Add(message);
            }

            await Clients.Group(roomName).SendAsync("ReceiveMessage", message);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            foreach (var room in _rooms)
            {
                var user = room.Value.Users.FirstOrDefault(u => u.Id == new Guid(Context.User.FindFirst(ClaimTypes.NameIdentifier).Value));
                if (user is not null)
                {
                    room.Value.Users.Remove(user);
                    await Clients.Group(room.Key).SendAsync("UserLeft", user);
                }
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
