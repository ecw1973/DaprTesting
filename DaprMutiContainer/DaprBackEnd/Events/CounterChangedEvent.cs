namespace DaprBackEnd.Events
{
    public class CounterChangedEvent
    {
        public int OldValue { get; set; }
        public int NewValue { get; set; }
    }
}