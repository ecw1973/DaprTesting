namespace ServiceOne.Events
{
    public class CounterChangedEvent
    {
        public int OldValue { get; set; }
        public int NewValue { get; set; }
        public override string ToString()
        {
            return $"{nameof(OldValue)}: {OldValue}, {nameof(NewValue)}: {NewValue}";
        }
    }
}