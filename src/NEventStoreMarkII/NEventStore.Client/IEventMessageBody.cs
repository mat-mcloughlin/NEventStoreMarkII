namespace NEventStore.Client
{
    using System.Threading.Tasks;

    public interface IEventMessageBody
    {
        Task<object> Read();
    }
}