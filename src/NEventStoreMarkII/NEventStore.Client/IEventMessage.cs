namespace NEventStore.Client
{
    using System.Collections.Generic;

    public interface IEventMessage
    {
        IReadOnlyDictionary<string, string> Headers { get; }

        IEventMessageBody Body { get; }
    }
}