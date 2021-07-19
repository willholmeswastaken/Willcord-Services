using Willcord.Services.Servers.Akka.Connectivity;

namespace Willcord.Services.Servers.Akka.Services
{
    interface IServerSessionHandler
    {
        void Handle(IServerSessionMessage message);
    }
}
