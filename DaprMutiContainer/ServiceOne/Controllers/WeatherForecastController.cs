using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceOne.Model;

namespace ServiceOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DaprClient daprClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DaprClient daprClient)
        {
            _logger = logger;
            this.daprClient = daprClient;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            //var ccEvent = new CounterChangedEvent {NewValue = 5, OldValue = 4};
            //await daprClient.PublishEventAsync("pubsub", "counterEvents", ccEvent);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}