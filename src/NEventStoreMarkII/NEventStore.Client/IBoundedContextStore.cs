namespace NEventStore.Client
{
    public interface IBoundedContextStore
    {
        IEventStream OpenStream(string streamId, int minRevision = 0, int maxRevision = int.MaxValue);

        void DeleteStream(string streamId);
    }
}