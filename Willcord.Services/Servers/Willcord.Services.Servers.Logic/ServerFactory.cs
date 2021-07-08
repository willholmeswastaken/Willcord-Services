using Microsoft.Toolkit.Diagnostics;
using Willcord.Services.Servers.Models;

namespace Willcord.Services.Servers.Logic
{
    public class ServerFactory : IServerFactory
    {
        public Server Create(string id, string name, string createdById)
        {
            Guard.IsNotNullOrWhiteSpace(id, nameof(id));
            Guard.IsNotNullOrWhiteSpace(name, nameof(name));
            Guard.IsNotNullOrWhiteSpace(createdById, nameof(createdById));
            
            return new Server
            {
                Id = id,
                Name = name,
                CreatedById = createdById
            };
        }
    }
}