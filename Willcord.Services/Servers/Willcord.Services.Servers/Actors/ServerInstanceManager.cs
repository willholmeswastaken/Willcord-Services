using Akka.Actor;
using Akka.DependencyInjection;
using Willcord.Services.Servers.Akka.Connectivity;

namespace Willcord.Services.Servers.Actors
{
    public class ServerInstanceManager : UntypedActor
    {
        private ServiceProvider _serviceProvider;

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case IServerSessionMessage serverMessage:
                    {
                        var child = Context
                            .Child(serverMessage.InstanceId)
                            .GetOrElse(() => Context.ActorOf(_serviceProvider.Props<ServerInstanceActor>(serverMessage.InstanceId), serverMessage.InstanceId));

                        child.Forward(serverMessage);
                        break;
                    }
                default:
                    Unhandled(message);
                    break;
            }
        }

        protected override void PreStart()
        {
            _serviceProvider = ServiceProvider.For(Context.System);
        }
    }
}
