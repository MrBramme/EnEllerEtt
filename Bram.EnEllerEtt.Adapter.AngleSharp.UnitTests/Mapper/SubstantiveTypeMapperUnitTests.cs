using Bram.EnEllerEtt.Adapter.AngleSharp.Mapper;
using Bram.EnEllerEtt.Core.Interface.Models;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.UnitTests
{
    public class SubstantiveTypeMapperUnitTests
    {
        [TestCase("utrum", SubstantiveType.En)]
        [TestCase("UTRUM", SubstantiveType.En)]
        [TestCase("Utrum", SubstantiveType.En)]
        [TestCase("neutrum", SubstantiveType.Ett)]
        [TestCase("NEUTRUM", SubstantiveType.Ett)]
        [TestCase("Neutrum", SubstantiveType.Ett)]
        public void FromString_ValidInput_MapsToCorrectType(string input, SubstantiveType expected)
        {
            // Given When
            var result = SubstantiveTypeMapper.FromString(input);

            // Then
            result.Should().Be(expected);
        }

        [Test]
        public void FromString_InvalidInput_ShouldThrowArgumentOutOfRangeException()
        {
            // Given
            var input = "unknown";

            // When
            Action act = () => SubstantiveTypeMapper.FromString(input);

            // Then
            act.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"Cannot map 'unknown' to SubstantiveType (Parameter 'input')\r\nActual value was unknown.");
        }
    }
}