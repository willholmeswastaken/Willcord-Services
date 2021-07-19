using System;

namespace Willcord.Services.Servers.Akka.Connectivity
{
    public class UpdateServer : IServerSessionMessage
    {
        public UpdateServer(string instanceId, string serverId, string name, string userId)
        {
            InstanceId = instanceId;
            ServerId = serverId;
            Name = name;
            UserId = userId;
        }

        public string InstanceId { get; }

        public string ServerId { get; }

        public string Name { get; }

        public string UserId { get; }
    }
}
