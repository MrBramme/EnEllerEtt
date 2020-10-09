using Bram.EnEllerEtt.Core;
using Bram.EnEllerEtt.Core.Interface;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.Rest
{
    public class RestService : IRestService
    {
        private readonly IRestClient _client;

        public RestService(RestConfiguration config, IRestClientFactory restClientFactory)
        {
            _client = restClientFactory.CreateRestClient(config.BaseUrl);
        }

        public async Task<string> GetHtmlForWordAsync(string word, CancellationToken ct)
        {
            var request = new RestRequest($"wiki/{word}", DataFormat.None);
            var response = await _client.ExecuteGetAsync(request, ct);
            return response.Content;
        }
    }
}
