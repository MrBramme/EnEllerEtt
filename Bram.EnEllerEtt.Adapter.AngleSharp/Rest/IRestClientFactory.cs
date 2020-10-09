using RestSharp;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.Rest
{
    public interface IRestClientFactory
    {
        IRestClient CreateRestClient(string baseUrl);
    }
}