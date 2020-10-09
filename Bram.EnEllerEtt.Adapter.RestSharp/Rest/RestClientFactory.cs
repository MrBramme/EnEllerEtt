using RestSharp;

namespace Bram.EnEllerEtt.Adapter.RestSharp.Rest
{
    public class RestClientFactory : IRestClientFactory
    {
        public IRestClient CreateRestClient(string baseUrl)
        {
            return new RestClient(baseUrl);
        }
    }
}
