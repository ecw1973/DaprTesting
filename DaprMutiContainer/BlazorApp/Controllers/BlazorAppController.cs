using System;
using System.Threading.Tasks;
using BlazorApp.Events;
using Dapr;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlazorAppController : Controller
    {
        private readonly IWebHostEnvironment environment;

        public BlazorAppController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [Topic("pubsub", "counterEvents")]
        [HttpPost]
        public async Task<IActionResult> Subscriber(CounterChangedEvent ccEvent)
        {
            Console.WriteLine("BlazorAppController received an event!");
            return Ok();
        }
    }
}