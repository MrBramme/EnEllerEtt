using RestSharp;
using System;

namespace Bram.EnEllerEtt.Adapter.RestSharp.Rest
{
    public class RestClientFactory : IRestClientFactory
    {
        public IRestClient CreateRestClient(string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentNullException();
            }
            return new RestClient(baseUrl);
        }
    }
}
