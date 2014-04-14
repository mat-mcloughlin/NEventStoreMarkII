namespace NEventStore.Client
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IEventStore
    {
        Task<string[]> GetBoundedContexts(CancellationToken cancellationToken);

        IBoundedContextStore GetBoundedContext(string boundedContextName = "default");

        void DeleteBoundedContext(string boundedContextName = "default");
    }

    public static class EventStoreExtensions
    {
        public static Task<string[]> GetBoundedContexts(this IEventStore eventStore)
        {
            return eventStore.GetBoundedContexts(CancellationToken.None);
        }
    }
}