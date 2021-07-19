using Willcord.Services.Servers.Models;

namespace Willcord.Services.Servers.Logic
{
    public interface IServerFactory
    {
        Server Create(string name, string createdById);
    }
}