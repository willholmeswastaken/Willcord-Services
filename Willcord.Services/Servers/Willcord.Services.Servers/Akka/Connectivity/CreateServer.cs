using System;

namespace Willcord.Services.Servers.Akka.Connectivity
{
    public class CreateServer : IServerSessionMessage
    {
        public CreateServer(string instanceId, string name, string userId)
        {
            InstanceId = instanceId;
            Name = name;
            UserId = userId;
        }

        public string InstanceId { get; }

        public string Name { get; }

        public string UserId { get; }
    }
}
