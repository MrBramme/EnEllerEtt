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
                Substantive = new SubstantiveResult
                {
                    SubstantiveType = SubstantiveType.Ett,
                    PluralGenitivBestamd = "barnens",
                    PluralGenitivObestamd = "barns",
                    PluralNominativBestamd = "barnen",
                    PluralNominativObestamd = "barn",
                    SingleGenitivBestamd = "barnets",
                    SingleGenitivObestamd = "barns",
                    SingleNominativBestamd = "barnet",
                    SingleNominativObestamd = "barn",
                },
                Verb = null
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
                Substantive = new SubstantiveResult
                {
                    SubstantiveType = SubstantiveType.En,
                    PluralGenitivBestamd = "dryckernas",
                    PluralGenitivObestamd = "dryckers",
                    PluralNominativBestamd = "dryckerna",
                    PluralNominativObestamd = "drycker",
                    SingleGenitivBestamd = "dryckens",
                    SingleGenitivObestamd = "drycks",
                    SingleNominativBestamd = "drycken",
                    SingleNominativObestamd = "dryck",
                },
                Verb = null
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
                Substantive = new SubstantiveResult
                {
                    SubstantiveType = SubstantiveType.En,
                    PluralGenitivBestamd = "matarnas",
                    PluralGenitivObestamd = "matars",
                    PluralNominativBestamd = "matarna",
                    PluralNominativObestamd = "matar",
                    SingleGenitivBestamd = "matens",
                    SingleGenitivObestamd = "mats",
                    SingleNominativBestamd = "maten",
                    SingleNominativObestamd = "mat",
                },
                Verb = null
            };

            // When
            var result = await _sut.ParseFromHtmlAsync(HtmlStrings.Mat, CancellationToken.None);

            // Then
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task ParseFromHtmlAsync_GiveGäspaHtmlString_ReturnsCorrectResult()
        {
            // Given
            var expected = new WordResult
            {
                Substantive = null,
                Verb = new VerbResult
                {
                    Infinitiv = "gäspa",
                    Presens = "gäspar",
                    Preteritum = "gäspade",
                    Supinum = "gäspat",
                    Imperativ = "gäspa"
                }
            };

            // When
            var result = await _sut.ParseFromHtmlAsync(HtmlStrings.Gäspa, CancellationToken.None);

            // Then
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task ParseFromHtmlAsync_GiveSpringaHtmlString_ReturnsCorrectResult()
        {
            // Given
            var expected = new WordResult
            {
                Substantive = new SubstantiveResult
                {
                    SubstantiveType = SubstantiveType.En,
                    PluralGenitivBestamd = "springornas",
                    PluralGenitivObestamd = "springors",
                    PluralNominativBestamd = "springorna",
                    PluralNominativObestamd = "springor",
                    SingleGenitivBestamd = "springans",
                    SingleGenitivObestamd = "springas",
                    SingleNominativBestamd = "springan",
                    SingleNominativObestamd = "springa",
                },
                Verb = new VerbResult
                {
                    Infinitiv = "springa",
                    Presens = "springer",
                    Preteritum = "sprang",
                    Supinum = "sprungit",
                    Imperativ = "spring"
                }
            };

            // When
            var result = await _sut.ParseFromHtmlAsync(HtmlStrings.Springa, CancellationToken.None);

            // Then
            result.Should().BeEquivalentTo(expected);
        }
    }
}
