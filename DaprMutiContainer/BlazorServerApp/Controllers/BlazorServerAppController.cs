using System;
using System.Threading.Tasks;
using BlazorServerApp.Events;
using Dapr;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlazorServerAppController : Controller
    {
        private readonly IWebHostEnvironment environment;

        public BlazorServerAppController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [Topic("pubsub", "counterEvents")]
        [HttpPost]
        public async Task<IActionResult> Subscriber(CounterChangedEvent ccEvent)
        {
            Console.WriteLine("BlazorServerAppController received an event!");
            return Ok();
        }
    }
}