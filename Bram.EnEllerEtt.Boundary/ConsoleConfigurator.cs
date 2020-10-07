using Bram.EnEllerEtt.Adapter.AngleSharp.Rest;
using Bram.EnEllerEtt.Adapter.RestSharp;
using Bram.EnEllerEtt.Core.Interface;
using Bram.EnEllerEtt.Core.Interface.Adapters;
using Bram.EnEllerEtt.Core.Interface.Services;
using Bram.EnEllerEtt.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Bram.EnEllerEtt.Boundary
{
    public static class ConsoleConfigurator
    {
        public static ServiceProvider Setup()
        {
            var restBaseUrl = ConfigurationManager.AppSettings["RestBaseUrl"];

            return new ServiceCollection()
                // Adapters
                .AddTransient<IRestService>(s => new RestService(restBaseUrl))
                .AddTransient<IWiktionaryParser, WiktionaryParser>()
                // Core
                .AddTransient<IWordLookupService, WordLookupLookupService>()
                .BuildServiceProvider();
        }
    }
}
