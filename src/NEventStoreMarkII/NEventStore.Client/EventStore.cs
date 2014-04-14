namespace NEventStore.Client
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class EventStore : IEventStore, IDisposable
    {
        private readonly HttpClient _httpClient;

        public EventStore(Uri baseAddress)
        {
            _httpClient = new HttpClient { BaseAddress = baseAddress };
        }

        public EventStore(HttpMessageHandler httpMessageHandler)
        {
            _httpClient = new HttpClient(httpMessageHandler){ BaseAddress = new Uri("http://localhost") };
        }

        public async Task<string[]> GetBoundedContexts(CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/boundedcontexts")
                .AcceptJson();
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode(); // TODO handle error better;
            return await response.Content.ReadAs<string[]>();
        }

        public IBoundedContextStore GetBoundedContext(string boundedContextName = "default")
        {
            throw new NotImplementedException();
        }

        public void DeleteBoundedContext(string boundedContextName = "default")
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}