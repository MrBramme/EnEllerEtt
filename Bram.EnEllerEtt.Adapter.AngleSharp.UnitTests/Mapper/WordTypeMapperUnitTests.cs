using Bram.EnEllerEtt.Adapter.AngleSharp.Mapper;
using Bram.EnEllerEtt.Core.Interface.Models;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.UnitTests
{
    public class WordTypeMapperUnitTests
    {
        [TestCase("utrum", WordType.En)]
        [TestCase("UTRUM", WordType.En)]
        [TestCase("Utrum", WordType.En)]
        [TestCase("neutrum", WordType.Ett)]
        [TestCase("NEUTRUM", WordType.Ett)]
        [TestCase("Neutrum", WordType.Ett)]
        public void FromString_ValidInput_MapsToCorrectType(string input, WordType expected)
        {
            // Given When
            var result = WordTypeMapper.FromString(input);

            // Then
            result.Should().Be(expected);
        }

        [Test]
        public void FromString_InvalidInput_ShouldThrow()
        {
            // Given
            var input = "unknown";

            // When
            Action act = () => WordTypeMapper.FromString(input);

            // Then
            act.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"Cannot map 'unknown' to WordType (Parameter 'input')\r\nActual value was unknown.");
        }
    }
}