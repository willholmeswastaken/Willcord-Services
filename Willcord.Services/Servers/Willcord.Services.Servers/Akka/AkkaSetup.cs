using Microsoft.Extensions.DependencyInjection;

namespace Willcord.Services.Servers.Akka
{
    public static class AkkaSetup
    {
        public static void AddAkka(this IServiceCollection services)
        {
            services.AddHostedService<AkkaService>();
        }
    }
}
