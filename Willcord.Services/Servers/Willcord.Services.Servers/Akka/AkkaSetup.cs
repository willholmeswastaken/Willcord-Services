using Microsoft.Extensions.DependencyInjection;
using Willcord.Services.Servers.Akka.Services;

namespace Willcord.Services.Servers.Akka
{
    public static class AkkaSetup
    {
        public static void AddAkka(this IServiceCollection services)
        {
            services.AddSingleton<IServerSessionHandler, AkkaService>();
            services.AddHostedService<AkkaService>(sp => (AkkaService)sp.GetRequiredService<IServerSessionHandler>());
        }
    }
}
