using System;
using System.Threading.Tasks;
using Dapr.Client;

namespace DaprCounter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string storeName = "statestore";
            const string key = "counter";
            var counter = 0;

            var daprClient = new DaprClientBuilder().Build();
            counter = await daprClient.GetStateAsync<int>(storeName, key);
            var data = new Item {Id = 1,Name = "Test1"};

            while (true)
            {
                //Console.WriteLine($"Counter = {counter++}");
                await daprClient.PublishEventAsync("pubsub", "test", data);
                await daprClient.SaveStateAsync(storeName, key, counter);
                Console.WriteLine("Still Here...");
                await Task.Delay(1000);
            }
        }
    }

    internal class Item
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
