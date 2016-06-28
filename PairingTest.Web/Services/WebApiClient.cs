using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace PairingTest.Web.Services
{
    public class WebApiClient : IGetApiClient
    {
        private readonly Uri _serverBaseUri;

        public WebApiClient(IServiceUriProvider serverUriProvider)
        {
            _serverBaseUri = new Uri(serverUriProvider.BaseUri);
        }

        public async Task<T> Get<T>(string requestUri)
        {
            return JsonConvert.DeserializeObject<T>(await GetAsync(requestUri));
        }

        public async Task<object> Get(string requestUri)
        {
            return JsonConvert.DeserializeObject(await GetAsync(requestUri));
        }

        private async Task<string> GetAsync(string requestUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _serverBaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode(); // throw if not a success code

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}