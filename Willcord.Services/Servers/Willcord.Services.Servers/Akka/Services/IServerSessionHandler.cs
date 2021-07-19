using Willcord.Services.Servers.Akka.Connectivity;

namespace Willcord.Services.Servers.Akka.Services
{
    public interface IServerSessionHandler
    {
        void Handle(IServerSessionMessage message);
    }
}
