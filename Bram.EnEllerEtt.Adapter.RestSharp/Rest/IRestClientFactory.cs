using RestSharp;

namespace Bram.EnEllerEtt.Adapter.RestSharp.Rest
{
    public interface IRestClientFactory
    {
        IRestClient CreateRestClient(string baseUrl);
    }
}