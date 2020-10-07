using Bram.EnEllerEtt.Core.Interface;
using RestSharp;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.Rest
{
    public class RestService : IRestService
    {
        public string GetHtmlForWord(string word)
        {
            var client = new RestClient("https://sv.wiktionary.org/");
            var request = new RestRequest($"/wiki/{word}", DataFormat.None);

            var response = client.Get(request);
            return response.Content;
        }
    }
}
