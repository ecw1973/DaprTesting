﻿namespace ServiceOne.Events
{
    public interface ICounterChangedEvent
    {
        int OldValue { get; set; }
        int NewValue { get; set; }
    }
}