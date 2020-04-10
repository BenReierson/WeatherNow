using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherNow.Services;

namespace WeatherNow.Utilities
{
    public class HttpRequestProvider : IRequestProvider
    {
        readonly HttpClient client;

        public HttpRequestProvider()
        {
            client = new HttpClient();
        }

        public async Task<TResult?> GetAsync<TResult>(string uri) where TResult : class
        {
            try
            {
                var httpResponse = await client.GetAsync(uri);
                var serializedResponse = await httpResponse.Content.ReadAsStringAsync();

                if (!httpResponse.IsSuccessStatusCode)
                    throw new ApiException(httpResponse.ReasonPhrase, uri, httpResponse.StatusCode, await httpResponse.Content.ReadAsStringAsync());

                return serializedResponse is null ? null : JsonConvert.DeserializeObject<TResult>(serializedResponse);
            }
            catch (ApiException) { throw; }
            catch (Exception ex)
            {
                var apiEx = new ApiException(ex.Message, ex, uri, HttpStatusCode.Ambiguous);
                throw apiEx;
            }
        }
    }
}
