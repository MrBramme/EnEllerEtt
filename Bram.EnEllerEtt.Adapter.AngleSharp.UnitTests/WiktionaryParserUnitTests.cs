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
                PluralGenitivBestämd = "barnens",
                PluralGenitivObestämd = "barns",
                PluralNominativBestämd = "barnen",
                PluralNominativObestämd = "barn",
                SingleGenitivBestämd = "barnets",
                SingleGenitivObestämd = "barns",
                SingleNominativBestämd = "barnet",
                SingleNominativObestämd = "barn",
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
                PluralGenitivBestämd = "dryckernas",
                PluralGenitivObestämd = "dryckers",
                PluralNominativBestämd = "dryckerna",
                PluralNominativObestämd = "drycker",
                SingleGenitivBestämd = "dryckens",
                SingleGenitivObestämd = "drycks",
                SingleNominativBestämd = "drycken",
                SingleNominativObestämd = "dryck",
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
                PluralGenitivBestämd = "maternas",
                PluralGenitivObestämd = "maters",
                PluralNominativBestämd = "materna",
                PluralNominativObestämd = "mater",
                SingleGenitivBestämd = "matens",
                SingleGenitivObestämd = "mats",
                SingleNominativBestämd = "maten",
                SingleNominativObestämd = "mat",
            };

            // When
            var result = await _sut.ParseFromHtmlAsync(HtmlStrings.Mat, CancellationToken.None);

            // Then
            result.Should().BeEquivalentTo(expected);
        }
    }
}
