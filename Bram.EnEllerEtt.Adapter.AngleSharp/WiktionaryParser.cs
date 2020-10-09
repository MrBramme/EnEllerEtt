using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using Bram.EnEllerEtt.Adapter.AngleSharp.Mapper;
using Bram.EnEllerEtt.Core.Interface.Adapters;
using Bram.EnEllerEtt.Core.Interface.Models;

namespace Bram.EnEllerEtt.Adapter.AngleSharp
{
    public class WiktionaryParser : IWiktionaryParser
    {
        public async Task<WordResult> ParseFromHtmlAsync(string html, CancellationToken ct)
        {
            var context = BrowsingContext.New(Configuration.Default);
            var document = await context.OpenAsync(req => req.Content(html), ct);

            var grammarTable = document.All.First(m => m.TagName.ToLower().Equals("table") && m.ClassList.Contains("grammar"));
            var cssSelectorForType = "table>tbody>tr>th.main";
            var typeOfWord = grammarTable.QuerySelectorAll(cssSelectorForType).Last().TextContent.Trim();

            var cssSelectorForWords = "table>tbody>tr>td>span>a";
            var words = grammarTable.QuerySelectorAll(cssSelectorForWords).Select(c => c.TextContent);

            var result = WordResultMapper.ToWordResult(typeOfWord, words.ToArray());
            return result;
        }

    }
}
