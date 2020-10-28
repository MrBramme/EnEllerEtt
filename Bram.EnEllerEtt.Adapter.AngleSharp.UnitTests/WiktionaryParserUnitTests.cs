using Bram.EnEllerEtt.Adapter.AngleSharp.UnitTests.Resources;
using Bram.EnEllerEtt.Core.Interface.Adapters;
using Bram.EnEllerEtt.Core.Interface.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.UnitTests
{
    public class WiktionaryParserUnitTests
    {
        private IWiktionaryParser _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new WiktionaryParser();
        }

        [Test]
        public async Task ParseFromHtmlAsync_GivenBarnHtmlString_ReturnsCorrectResult()
        {
            // Given
            var expected = new WordResult
            {
                WordType = WordType.Ett,
                PluralGenitivBestamd = "barnens",
                PluralGenitivObestamd = "barns",
                PluralNominativBestamd = "barnen",
                PluralNominativObestamd = "barn",
                SingleGenitivBestamd = "barnets",
                SingleGenitivObestamd = "barns",
                SingleNominativBestamd = "barnet",
                SingleNominativObestamd = "barn",
            };

            // When
            var result = await _sut.ParseFromHtmlAsync(HtmlStrings.Barn, CancellationToken.None);

            // Then
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task ParseFromHtmlAsync_GivenDryckHtmlString_ReturnsCorrectResult()
        {
            // Given
            var expected = new WordResult
            {
                WordType = WordType.En,
                PluralGenitivBestamd = "dryckernas",
                PluralGenitivObestamd = "dryckers",
                PluralNominativBestamd = "dryckerna",
                PluralNominativObestamd = "drycker",
                SingleGenitivBestamd = "dryckens",
                SingleGenitivObestamd = "drycks",
                SingleNominativBestamd = "drycken",
                SingleNominativObestamd = "dryck",
            };

            // When
            var result = await _sut.ParseFromHtmlAsync(HtmlStrings.Dryck, CancellationToken.None);

            // Then
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task ParseFromHtmlAsync_GivenMatHtmlString_ReturnsCorrectResult()
        {
            // Given
            var expected = new WordResult
            {
                WordType = WordType.En,
                PluralGenitivBestamd = "matarnas",
                PluralGenitivObestamd = "matars",
                PluralNominativBestamd = "matarna",
                PluralNominativObestamd = "matar",
                SingleGenitivBestamd = "matens",
                SingleGenitivObestamd = "mats",
                SingleNominativBestamd = "maten",
                SingleNominativObestamd = "mat",
            };

            // When
            var result = await _sut.ParseFromHtmlAsync(HtmlStrings.Mat, CancellationToken.None);

            // Then
            result.Should().BeEquivalentTo(expected);
        }
    }
}
