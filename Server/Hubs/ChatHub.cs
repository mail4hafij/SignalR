using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace Server.Hubs
{
    public class ChatHub : Hub
    {
        // Thread-safe counter to track the number of connected clients
        private static int _clientCount = 0;
        private static ConcurrentDictionary<string, string> _clientUsernames = new ConcurrentDictionary<string, string>();

        public override async Task OnConnectedAsync()
        {
            // Increment the client count and assign a username
            _clientCount++;
            string username = $"Guest{_clientCount}";

            // Store the username in the dictionary
            _clientUsernames[Context.ConnectionId] = username;

            // Notify all clients that a new user has joined
            await Clients.All.SendAsync("ReceiveMessage", "System", $"{username} has joined the chat.");

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Retrieve the username of the disconnected client
            if (_clientUsernames.TryRemove(Context.ConnectionId, out string username))
            {
                // Notify all clients that the user has left
                await Clients.All.SendAsync("ReceiveMessage", "System", $"{username} has left the chat.");
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            // Retrieve the username of the sender
            if (_clientUsernames.TryGetValue(Context.ConnectionId, out string username))
            {
                // Broadcast the message to all clients
                await Clients.All.SendAsync("ReceiveMessage", username, message);
            }
        }
    }
}
