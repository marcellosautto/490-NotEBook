using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotEBookWeb.Models
{
    public class NotEBookChat : Hub
    {
        public const string HubUrl = "/chat";

        public async Task Broadcast(string username, string message)
        {
            
            await Clients.All.SendAsync("Broadcast", username, message);
        }
        
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected!");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
    }
}
