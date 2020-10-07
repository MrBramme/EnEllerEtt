using Bram.EnEllerEtt.Adapter.AngleSharp.Rest;
using Bram.EnEllerEtt.Adapter.RestSharp;
using Bram.EnEllerEtt.Core.Interface;
using Bram.EnEllerEtt.Core.Interface.Adapters;
using Bram.EnEllerEtt.Core.Interface.Services;
using Bram.EnEllerEtt.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bram.EnEllerEtt.Boundary
{
    public static class ConsoleConfigurator
    {
        public static ServiceProvider Setup()
        {
            return new ServiceCollection()
                // Adapters
                .AddTransient<IRestService, RestService>()
                .AddTransient<IWiktionaryParser, WiktionaryParser>()
                // Core
                .AddTransient<IWordLookupService, WordLookupLookupService>()
                .BuildServiceProvider();
        }
    }
}
