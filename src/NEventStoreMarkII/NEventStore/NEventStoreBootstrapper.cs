namespace NEventStore
{
    using System.Collections.Generic;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;
    using NEventStore.Persistence;

    internal class NEventStoreBootstrapper : DefaultNancyBootstrapper
    {
        private readonly IPersistStreams _persistStreams;

        public NEventStoreBootstrapper(IPersistStreams persistStreams)
        {
            _persistStreams = persistStreams;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register(_persistStreams);
        }

        protected override IEnumerable<ModuleRegistration> Modules
        {
            get
            {
                return new[]
                {
                    new ModuleRegistration(typeof (BoundedContextModule))
                };
            }
        }
    }
}