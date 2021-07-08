using Willcord.Services.Servers.Models;

namespace Willcord.Services.Servers.Logic
{
    public interface IServerFactory
    {
        Server Create(string id, string name, string createdById);
    }
}