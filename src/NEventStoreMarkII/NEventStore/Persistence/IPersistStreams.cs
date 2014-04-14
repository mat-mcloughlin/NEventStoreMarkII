namespace NEventStore.Persistence
{
    using System.Threading.Tasks;

    public interface IPersistStreams
    {
        Task<string[]> GetBoundedContexts();
    }
}