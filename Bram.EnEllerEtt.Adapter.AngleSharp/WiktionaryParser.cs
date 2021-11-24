﻿using AngleSharp;
using AngleSharp.Dom;
using Bram.EnEllerEtt.Adapter.AngleSharp.Mapper;
using Bram.EnEllerEtt.Core.Interface.Adapters;
using Bram.EnEllerEtt.Core.Interface.Exceptions;
using Bram.EnEllerEtt.Core.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.Adapter.AngleSharp
{
    public class WiktionaryParser : IWiktionaryParser
    {
        public async Task<WordResult> ParseFromHtmlAsync(string html, CancellationToken ct)
        {
            var document = await GetDocumentFromHtmlString(html, ct);

            var isSubstantiv = document.All.Any(m => m.Id != null && m.Id.Equals("Substantiv") && m.ClassList.Contains("mw-headline"));
            if (isSubstantiv)
            {
                var grammarTables = document.All.Where(m => m.TagName.ToLower().Equals("table") && m.ClassList.Contains("grammar"));
                var grammarTable = grammarTables.First(t => t.Children[0].Children[1].ChildElementCount == 5);

                var typeOfWord = ParseTypeOfWord(grammarTable);
                var words = ParseWordConjugations(grammarTable);

                return WordResultMapper.ToWordResult(typeOfWord, words.ToArray());
            }
            var isVerb = document.All.Any(m => m.Id != null && m.Id.Equals("Verb") && m.ClassList.Contains("mw-headline"));
            if (isVerb)
            {
                throw new NotImplementedException();
            }
            throw new WordNotFoundException("Could not parse HTML content");

        }

        private static IEnumerable<string> ParseWordConjugations(IElement grammarTable)
        {
            var cssSelectorForWords = "table>tbody>tr>td>span>a";
            var words = grammarTable.QuerySelectorAll(cssSelectorForWords).Select(c => c.TextContent);
            return words;
        }

        private static string ParseTypeOfWord(IElement grammarTable)
        {
            var cssSelectorForType = "table>tbody>tr>th.main";
            var typeOfWord = grammarTable.QuerySelectorAll(cssSelectorForType).Last().TextContent.Trim();
            return typeOfWord;
        }

        private static Task<IDocument> GetDocumentFromHtmlString(string html, CancellationToken ct)
        {
            var context = BrowsingContext.New(Configuration.Default);
            return context.OpenAsync(req => req.Content(html), ct);
        }
    }
}
