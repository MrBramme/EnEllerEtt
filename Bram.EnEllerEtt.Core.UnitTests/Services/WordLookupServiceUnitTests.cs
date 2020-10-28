using Bram.EnEllerEtt.Core.Interface.Adapters;
using Bram.EnEllerEtt.Core.Interface.Models;
using Bram.EnEllerEtt.Core.Interface.Services;
using Bram.EnEllerEtt.Core.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.Core.UnitTests.Services
{
    [TestFixture]
    public class WordLookupServiceUnitTests
    {
        private IWordLookupService _sut;
        private Mock<IRestService> _restServiceMock;
        private Mock<IWiktionaryParser> _wiktionaryParserMock;

        [SetUp]
        public void SetUp()
        {
            _restServiceMock = new Mock<IRestService>();
            _wiktionaryParserMock = new Mock<IWiktionaryParser>();
            _sut = new WordLookupService(_restServiceMock.Object, _wiktionaryParserMock.Object);
        }

        [Test]
        public async Task GetResultForWordAsync_GivenValidInpuy_ShouldCallServices()
        {
            // Given
            var word = "ThisWord";
            var restResult = "restResult";
            var expected = new WordResult();

            _restServiceMock.Setup(rest => rest.GetHtmlForWordAsync(It.Is<string>(w => w.Equals(word)), It.IsAny<CancellationToken>()))
                .ReturnsAsync(restResult);
            _wiktionaryParserMock.Setup(parser => parser.ParseFromHtmlAsync(It.Is<string>(html => html.Equals(restResult)), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            // When
            var result = await _sut.GetResultForWordAsync(word, CancellationToken.None);

            // Then
            result.Should().Be(expected);
        }
    }
}