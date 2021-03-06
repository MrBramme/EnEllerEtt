﻿using Bram.EnEllerEtt.Core.Interface.Adapters;
using Bram.EnEllerEtt.Core.Interface.Config;
using Bram.EnEllerEtt.Core.Interface.Exceptions;
using RestSharp;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.Adapter.RestSharp.Rest
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
            var request = new RestRequest($"wiki/{word.ToLower()}", DataFormat.None);
            var response = await _client.ExecuteGetAsync(request, ct);
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                throw new WordNotFoundException($"Could not find word '{word}'");
            }

            return response.Content;
        }
    }
}
