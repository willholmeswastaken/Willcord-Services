using Akka.Actor;
using Akka.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Willcord.Services.Servers.Akka
{
    public sealed class AkkaService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHostApplicationLifetime _applicationLifetime;

        private ActorSystem _system;

        public AkkaService(IServiceProvider serviceProvider, IHostApplicationLifetime applicationLifetime)
        {
            _serviceProvider = serviceProvider;
            _applicationLifetime = applicationLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var spSetup = ServiceProviderSetup.Create(_serviceProvider);

            var bootStrapSetup = BootstrapSetup.Create();
            var actorSystemSetup = spSetup.And(bootStrapSetup);

            _system = ActorSystem.Create("ServerSys", actorSystemSetup);

            _system.WhenTerminated.ContinueWith(tr => _applicationLifetime.StopApplication());

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _system.Terminate();
        }
    }
}
