// ReSharper disable once CheckNamespace
namespace System.Net.Http
{
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    internal static class HttpExtensions
    {
        internal static HttpRequestMessage AcceptJson(this HttpRequestMessage request)
        {
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return request;
        }

        internal static async Task<T> ReadAs<T>(this HttpContent content)
        {
            string value = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}