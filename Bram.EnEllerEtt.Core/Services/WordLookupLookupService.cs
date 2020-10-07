using Bram.EnEllerEtt.Core.Interface;
using Bram.EnEllerEtt.Core.Interface.Adapters;
using Bram.EnEllerEtt.Core.Interface.Models;
using Bram.EnEllerEtt.Core.Interface.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.Core.Services
{
    public class WordLookupLookupService : IWordLookupService
    {
        private readonly IRestService _restService;
        private readonly IWiktionaryParser _wiktionaryParser;

        public WordLookupLookupService(IRestService restService, IWiktionaryParser wiktionaryParser)
        {
            _restService = restService;
            _wiktionaryParser = wiktionaryParser;
        }
        public async Task<WordResult> GetResultForWordAsync(string word, CancellationToken ct)
        {
            var result = _restService.GetHtmlForWord(word);
            return await _wiktionaryParser.ParseFromHtmlAsync(result, ct);
        }
    }
}
