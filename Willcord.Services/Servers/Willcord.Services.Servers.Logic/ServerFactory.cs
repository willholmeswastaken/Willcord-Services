using Microsoft.Toolkit.Diagnostics;
using System;
using Willcord.Services.Servers.Models;

namespace Willcord.Services.Servers.Logic
{
    public class ServerFactory : IServerFactory
    {
        public Server Create(string name, string createdById)
        {
            Guard.IsNotNullOrWhiteSpace(name, nameof(name));
            Guard.IsNotNullOrWhiteSpace(createdById, nameof(createdById));
            
            return new Server
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                CreatedById = createdById
            };
        }
    }
}