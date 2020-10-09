using Bram.EnEllerEtt.Adapter.RestSharp.Rest;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using System;

namespace Bram.EnEllerEtt.Adapter.RestSharp.UnitTests.Rest
{
    public class RestClientFactoryUnitTests
    {
        private IRestClientFactory _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new RestClientFactory();
        }

        [Test]
        public void CreateRestClient_givenValidBaseUrl_ReturnsARestClient()
        {
            // Given
            var baseUrl = "http://www.google.com";

            // When
            var result = _sut.CreateRestClient(baseUrl);

            // Then
            result.Should().BeOfType<RestClient>();
            result.BaseUrl.Should().BeEquivalentTo(new Uri(baseUrl));
        }

        [Test]
        public void CreateRestClient_givenEmptyBaseUrl_ThrowsArgumentNullException()
        {
            // Given
            var baseUrl = "";

            // When
            Action act = () => _sut.CreateRestClient(baseUrl);

            // Then
            act.Should().Throw<ArgumentNullException>();
        }
    }
}