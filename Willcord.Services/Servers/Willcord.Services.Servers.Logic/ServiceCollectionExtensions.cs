using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace Willcord.Services.Servers.Logic
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static void AddCommon(this IServiceCollection services)
        {
            services.AddSingleton<IServerFactory, ServerFactory>();
        }
    }
}