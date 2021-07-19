using Microsoft.AspNetCore.Mvc;
using System;
using Willcord.Services.Servers.Akka.Connectivity;
using Willcord.Services.Servers.Akka.Services;

namespace Willcord.Services.Servers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly IServerSessionHandler _serverSessionHandler;

        public ServerController(IServerSessionHandler serverSessionHandler)
        {
            _serverSessionHandler = serverSessionHandler;
        }


        [HttpPost]
        public IActionResult Create(string name)
        {
            var mockSignalRSessionId = Guid.NewGuid().ToString();
            var mockUserId = Guid.NewGuid().ToString();

            _serverSessionHandler.Handle(new CreateServer(mockSignalRSessionId, name, mockUserId));

            return Ok();
        }
    }
}
