namespace ServiceOne.Events
{
    public class CounterChangedEvent: ICounterChangedEvent
    {
        public int OldValue { get; set; }
        public int NewValue { get; set; }

        public override string ToString()
        {
            return $"Event {GetType().Name} with {nameof(OldValue)}: {OldValue}, {nameof(NewValue)}: {NewValue}";
        }
    }
}