namespace NEventStore
{
    using Nancy;
    using NEventStore.Persistence;

    internal class BoundedContextModule : NancyModule
    {
        public BoundedContextModule(IPersistStreams persistStreams) : base("boundedcontexts")
        {
            Get["/", true] = async (_, __) =>
            {
                string[] strings = await persistStreams.GetBoundedContexts();
                return Negotiate.WithModel(strings);
            };
        }
    }
}