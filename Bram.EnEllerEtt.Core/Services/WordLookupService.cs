using Bram.EnEllerEtt.Core.Interface.Adapters;
using Bram.EnEllerEtt.Core.Interface.Models;
using Bram.EnEllerEtt.Core.Interface.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.Core.Services
{
    public class WordLookupService : IWordLookupService
    {
        private readonly IRestService _restService;
        private readonly IWiktionaryParser _wiktionaryParser;

        public WordLookupService(IRestService restService, IWiktionaryParser wiktionaryParser)
        {
            _restService = restService;
            _wiktionaryParser = wiktionaryParser;
        }
        public async Task<WordResult> GetResultForWordAsync(string word, CancellationToken ct)
        {
            var result = await _restService.GetHtmlForWordAsync(word, ct);
            return await _wiktionaryParser.ParseFromHtmlAsync(result, ct);
        }
    }
}
