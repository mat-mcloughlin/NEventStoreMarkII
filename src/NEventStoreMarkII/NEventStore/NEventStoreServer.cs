namespace NEventStore
{
    using System;
    using NEventStore.Client;
    using NEventStore.Persistence;
    using Owin;
    using Owin.EmbeddedHost;

    public class NEventStoreServer : IDisposable
    {
        private readonly OwinEmbeddedHost _owinEmbeddedHost;

        public NEventStoreServer(IPersistStreams persistStreams)
        {
            var bootstrapper = new NEventStoreBootstrapper(persistStreams);
            _owinEmbeddedHost =
                OwinEmbeddedHost.Create(app => app.UseNancy(options => options.Bootstrapper = bootstrapper));
        }

        public void Dispose()
        {
            _owinEmbeddedHost.Dispose();
        }

        public IEventStore CreateStore()
        {
            return new EventStore(new OwinHttpMessageHandler(environment => _owinEmbeddedHost.Invoke(environment)));
        }
    }
}