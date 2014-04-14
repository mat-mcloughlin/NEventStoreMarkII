namespace NEventStore.Persistence.InMemory
{
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading.Tasks;

    public class InMemoryPersistence : IPersistStreams
    {
        private readonly ConcurrentDictionary<string, BoundedContext> _boundedContexts = new ConcurrentDictionary<string, BoundedContext>();

        public InMemoryPersistence()
        {
            _boundedContexts.TryAdd("default", new BoundedContext());
        }

        public Task<string[]> GetBoundedContexts()
        {
            return Task.FromResult(_boundedContexts.Keys.ToArray());
        }

        private class BoundedContext
        {
            
        }
    }
}