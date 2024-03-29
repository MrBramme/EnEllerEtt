using Bram.EnEllerEtt.Adapter.AngleSharp.Mapper;
using Bram.EnEllerEtt.Core.Interface.Exceptions;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using System;
using System.Linq;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.UnitTests
{
    public class SubstantiveResultMapperUnitTests
    {
        [Test]
        public void ToSubstantiveResultt_ValidInput_MapsToCorrectType()
        {
            // Given
            var wordType = "utrum";
            var conjugations = Enumerable.Range(0, 8).Select(i => $"conjugation{i}").ToArray();
            var expectedWordType = SubstantiveTypeMapper.FromString(wordType);

            // When
            var result = SubstantiveResultMapper.ToSubstantiveResult(wordType, conjugations);

            // Then
            using (new AssertionScope())
            {
                result.SubstantiveType.Should().Be(expectedWordType);

                result.SingleNominativObestamd.Should().Be(conjugations[0]);
                result.SingleNominativBestamd.Should().Be(conjugations[1]);
                result.PluralNominativObestamd.Should().Be(conjugations[2]);
                result.PluralNominativBestamd.Should().Be(conjugations[3]);
                result.SingleGenitivObestamd.Should().Be(conjugations[4]);
                result.SingleGenitivBestamd.Should().Be(conjugations[5]);
                result.PluralGenitivObestamd.Should().Be(conjugations[6]);
                result.PluralGenitivBestamd.Should().Be(conjugations[7]);
            }

        }

        [Test]
        public void FromString_InvalidInput_ShouldThrow()
        {
            // Given
            var wordType = "utrum";
            var conjugations = new[] { "just one will fail" };

            // When
            Action act = () => SubstantiveResultMapper.ToSubstantiveResult(wordType, conjugations);

            // Then
            act.Should().Throw<SubstantiveResultMapperException>().WithMessage("Error while mapping SubstantiveResult");
        }
    }
}