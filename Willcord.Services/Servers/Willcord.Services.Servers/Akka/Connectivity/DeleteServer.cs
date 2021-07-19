using System;

namespace Willcord.Services.Servers.Akka.Connectivity
{
    public class DeleteServer : IServerSessionMessage
    {
        public DeleteServer(string instanceId, string serverId, string userId)
        {
            InstanceId = instanceId;
            ServerId = serverId;
            UserId = userId;
        }

        public string InstanceId { get; }

        public string ServerId { get; }

        public string UserId { get; }
    }
}
