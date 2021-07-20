using System.Threading.Tasks;
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceTwo.Events;

namespace ServiceTwo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceTwoController : ControllerBase
    {
        private readonly ILogger<ServiceTwoController> _logger;
        private DaprClient daprClient;

        public ServiceTwoController(ILogger<ServiceTwoController> logger, DaprClient daprClient)
        {
            _logger = logger;
            this.daprClient = daprClient;
        }

        [Topic("pubsub", "counterEvents")]
        [HttpPost]
        public async Task<IActionResult> Subscriber(CounterChangedEvent ccEvent)
        {
            _logger.LogInformation("Received CounterChangedEvent Event: ", ccEvent);
            return Ok();
        }
    }
}