using Bram.EnEllerEtt.Core.Interface;
using RestSharp;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.Rest
{
    public class RestService : IRestService
    {
        private RestClient _client;

        public RestService(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public string GetHtmlForWord(string word)
        {
            var request = new RestRequest($"/wiki/{word}", DataFormat.None);

            var response = _client.Get(request);
            return response.Content;
        }
    }
}
