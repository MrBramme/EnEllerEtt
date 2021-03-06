﻿using Bram.EnEllerEtt.Adapter.RestSharp.Rest;
using Bram.EnEllerEtt.Core.Interface.Adapters;
using Bram.EnEllerEtt.Core.Interface.Config;
using Bram.EnEllerEtt.Core.Interface.Exceptions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.Adapter.RestSharp.UnitTests.Rest
{
    public class RestServiceUnitTests
    {
        private IRestService _sut;
        private RestConfiguration _config;
        private Mock<IRestClientFactory> _restClientFactoryMock;
        private Mock<IRestClient> _restClientMock;

        [SetUp]
        public void Setup()
        {
            _config = new RestConfiguration { BaseUrl = "test" };
            _restClientFactoryMock = new Mock<IRestClientFactory>();
            _restClientMock = new Mock<IRestClient>();
            _restClientFactoryMock.Setup(x => x.CreateRestClient(It.IsAny<string>())).Returns(_restClientMock.Object);
            _sut = new RestService(_config, _restClientFactoryMock.Object);
        }

        [Test]
        public void Constructor_CallsRestClientFactoryWithCorrectParam()
        {
            // Given  When Then
            _restClientFactoryMock.Verify(x => x.CreateRestClient(It.Is<string>(url => url.Equals(_config.BaseUrl))), Times.Once);
        }

        [Test]
        public async Task GetHtmlForWordAsync_ExecutesRequestAndReturnsResponse()
        {
            // Given
            var word = "barn";
            var expectedResponse = new RestResponse { Content = "expected" };
            _restClientMock.Setup(x => x.ExecuteGetAsync(It.Is<RestRequest>(req => req.Resource.Equals($"wiki/{word}")),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // When
            var result = await _sut.GetHtmlForWordAsync(word, CancellationToken.None);

            // Then
            _restClientMock.Verify(x => x.ExecuteGetAsync(It.Is<RestRequest>(req => req.Resource.Equals($"wiki/{word}")), It.IsAny<CancellationToken>()), Times.Once);
            result.Should().Be(expectedResponse.Content);
        }

        [Test]
        public void GetHtmlForWordAsync_WhenStatusCodeNotFound_ThrowsWordNotFoundException()
        {
            // Given
            var word = "barn";
            var expectedResponse = new RestResponse { StatusCode = HttpStatusCode.NotFound };
            _restClientMock.Setup(x => x.ExecuteGetAsync(It.Is<RestRequest>(req => req.Resource.Equals($"wiki/{word}")),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // When
            Func<Task> act = async () => { await _sut.GetHtmlForWordAsync(word, CancellationToken.None); };

            // Then
            act.Should().Throw<WordNotFoundException>().WithMessage($"Could not find word '{word}'");
        }

        [Test]
        public async Task GetHtmlForWordAsync_MakesWordLowerCase()
        {
            // Given
            var word = "Barn";
            var expectedWord = word.ToLower();
            var expectedResponse = new RestResponse { Content = "expected" };
            _restClientMock.Setup(x => x.ExecuteGetAsync(It.Is<RestRequest>(req => req.Resource.Equals($"wiki/{expectedWord}")),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // When
            var result = await _sut.GetHtmlForWordAsync(word, CancellationToken.None);

            // Then
            _restClientMock.Verify(x => x.ExecuteGetAsync(It.Is<RestRequest>(req => req.Resource.Equals($"wiki/{expectedWord}")), It.IsAny<CancellationToken>()), Times.Once);
            result.Should().Be(expectedResponse.Content);
        }
    }
}
