using Akka.Actor;
using Akka.Event;
using Akka.Streams;
using Akka.Streams.Dsl;
using System;
using Willcord.Services.Servers.Akka.Connectivity;
using Willcord.Services.Servers.Logic;

namespace Willcord.Services.Servers.Actors
{
    public class ServerInstanceActor : UntypedActor
    {
        private readonly ILoggingAdapter _log = Context.GetLogger();

        private readonly string _sessionId;
        private readonly IServerFactory _serverFactory;
        private readonly TimeSpan _idleTimeout = TimeSpan.FromMinutes(20);

        public ServerInstanceActor(string sessionId, IServerFactory serverFactory)
        {
            _sessionId = sessionId;
            _serverFactory = serverFactory;
        }


        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case CreateServer create:
                    {
                        _log.Info($"User {create.UserId} is creating a server named {create.Name}");
                        _serverFactory.Create(create.Name, create.UserId);

                        // todo: notify signalR hubs of new server.
                        break;
                    }
                default:
                    {
                        Unhandled(message);
                        break;
                    }
            }
        }

        protected override void PreStart()
        {
            _log.Info("Started server session [{0}]", _sessionId);

            // todo: more signalr code
            //var materializer = Context.Materializer();
            //var (sourceRef, source) = Source.ActorRef<IServerSessionMessage>(1000, OverflowStrategy.DropHead)
            //    .PreMaterialize(materializer);

            //_streamsDebouncer = sourceRef;
            //source.GroupedWithin(10, TimeSpan.FromMilliseconds(75)).RunForeach(TransmitActions, materializer);

            // idle timeout all drawings after 20 minutes
            Context.SetReceiveTimeout(_idleTimeout);
        }

        // todo: rework this once signalr is in
        //private void TransmitActions(IEnumerable<IPaintSessionMessage> actions)
        //{
        //    var createActions = actions.Where(a => a is CreateServer).Select(a => ((CreateServer)a));

        //    _log.Info("BATCHED {0} create actions", createActions.Count());

        //    createActions.ForEach(c => { c.Points = addActions.Where(a => a.Id == c.Id).Select(a => a.Point).ToList(); });

        //    _hubHandler.PushConnectedStrokes(_sessionId, createActions.ToArray());
        //    _connectedStrokes.AddRange(createActions);

        //    addActions.GroupBy(a => a.Id).ForEach(add => {
        //        _connectedStrokes.Where(c => c.Id == add.Key).First().Points.AddRange(add.Select(a => a.Point));

        //        // sync ALL users
        //        // TODO: look into zero-copy for this
        //        _hubHandler.AddPointsToConnectedStroke(_sessionId, add.Key, add.Select(a => a.Point).ToArray());
        //    });
        //}
    }
}
