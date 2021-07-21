using System.Threading.Tasks;
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceOne.Events;

namespace ServiceOne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CounterEventController : ControllerBase
    {
        private const string DaprPubSubName = "pubsub";
        private readonly ILogger<CounterEventController> _logger;
        private readonly DaprClient daprClient;

        public CounterEventController(ILogger<CounterEventController> logger, DaprClient daprClient)
        {
            _logger = logger;
            this.daprClient = daprClient;
        }

        [HttpPost(nameof(CounterResetEvent))]
        [Topic(DaprPubSubName, nameof(CounterResetEvent))]
        public void Handle(CounterResetEvent ccEvent)
        {
            _logger.LogInformation("Event Received: [{0}]", ccEvent);
        }

        [HttpPost(nameof(CounterChangedEvent))]
        [Topic(DaprPubSubName, nameof(CounterChangedEvent))]
        public void Handle(CounterChangedEvent ccEvent)
        {
            _logger.LogInformation("Event Received: [{0}]", ccEvent);
        }
    }
}