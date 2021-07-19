using System;

namespace Willcord.Services.Servers.Akka.Connectivity
{
    public class LeaveServer : IServerSessionMessage
    {
        public string InstanceId { get; }

        public string ServerId { get; }

        public string UserId { get; }
    }
}
