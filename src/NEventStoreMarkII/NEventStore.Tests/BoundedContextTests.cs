namespace NEventStore.Tests
{
    using System.Threading.Tasks;
    using FluentAssertions;
    using NEventStore.Client;
    using NEventStore.Persistence.InMemory;
    using Xunit;

    public class BoundedContextTests
    {
        [Fact]
        public async Task Can_get_list_of_bounded_contexts()
        {
            using (var server = new NEventStoreServer(new InMemoryPersistence()))
            {
                IEventStore eventStore = server.CreateStore();
                string[] contexts = await eventStore.GetBoundedContexts();

                contexts.Should().NotBeNull();
                contexts.Should().Contain("default");
            }
        }
    }
}