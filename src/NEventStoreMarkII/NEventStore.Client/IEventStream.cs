namespace NEventStore.Client
{
    using System;
    using System.Collections.Generic;

    public interface IEventStream : IDisposable
    {
        string StreamId { get; }

        int StreamRevision { get; }

        int CommitSequence { get; }

        IReadOnlyCollection<IEventMessage> CommittedEvents { get; }

        IReadOnlyCollection<IEventMessage> UncommittedEvents { get; } 

        void Append(IReadOnlyDictionary<string, string> headers, object body);

        void CommitChanges(Guid commitId);
    }
}