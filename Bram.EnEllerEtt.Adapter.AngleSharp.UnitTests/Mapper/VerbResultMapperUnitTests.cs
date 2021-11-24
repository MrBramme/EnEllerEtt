using Bram.EnEllerEtt.Adapter.AngleSharp.Mapper;
using Bram.EnEllerEtt.Core.Interface.Exceptions;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using System;
using System.Linq;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.UnitTests
{
    public class VerbResultMapperUnitTests
    {
        [Test]
        public void ToVerbResult_ValidInput_MapsToCorrectType()
        {
            // Given
            var conjugations = Enumerable.Range(0, 10).Select(i => $"conjugation{i}").ToArray();

            // When
            var result = VerbResultMapper.ToVerbResult(conjugations);

            // Then
            using (new AssertionScope())
            {
                result.Infinitiv.Should().Be(conjugations[0]);
                result.Presens.Should().Be(conjugations[2]);
                result.Preteritum.Should().Be(conjugations[4]);
                result.Supinum.Should().Be(conjugations[6]);
                result.Imperativ.Should().Be(conjugations[8]);
            }

        }

        [Test]
        public void FromString_InvalidInput_ShouldThrow()
        {
            // Given
            var conjugations = new[] { "just one will fail" };

            // When
            Action act = () => VerbResultMapper.ToVerbResult(conjugations);

            // Then
            act.Should().Throw<VerbResultMapperException>().WithMessage("Error while mapping VerbResult");
        }
    }
}