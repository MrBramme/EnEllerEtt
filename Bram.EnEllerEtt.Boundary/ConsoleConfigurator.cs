using Bram.EnEllerEtt.Adapter.AngleSharp;
using Bram.EnEllerEtt.Adapter.RestSharp.Rest;
using Bram.EnEllerEtt.Core.Interface.Adapters;
using Bram.EnEllerEtt.Core.Interface.Config;
using Bram.EnEllerEtt.Core.Interface.Services;
using Bram.EnEllerEtt.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bram.EnEllerEtt.Boundary
{
    public static class ConsoleConfigurator
    {
        public static ServiceProvider Setup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            var restConfiguration = new RestConfiguration();
            config.GetSection("Rest").Bind(restConfiguration);

            return new ServiceCollection()
                .AddSingleton(restConfiguration)
                // Adapters
                .AddSingleton<IRestClientFactory, RestClientFactory>()
                .AddTransient<IRestService, RestService>()
                .AddTransient<IWiktionaryParser, WiktionaryParser>()
                // Core
                .AddTransient<IWordLookupService, WordLookupService>()
                .BuildServiceProvider();
        }
    }
}
