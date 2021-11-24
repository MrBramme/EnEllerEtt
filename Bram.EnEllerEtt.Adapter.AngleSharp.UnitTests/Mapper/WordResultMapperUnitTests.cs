using Bram.EnEllerEtt.Adapter.AngleSharp.Mapper;
using Bram.EnEllerEtt.Core.Interface.Exceptions;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using System;
using System.Linq;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.UnitTests
{
    public class WordResultMapperUnitTests
    {
        [Test]
        public void ToWordResult_ValidInput_MapsToCorrectType()
        {
            // Given
            var wordType = "utrum";
            var conjugations = Enumerable.Range(0, 8).Select(i => $"conjugation{i}").ToArray();
            var expectedWordType = SubstantiveTypeMapper.FromString(wordType);

            // When
            var result = WordResultMapper.ToWordResult(wordType, conjugations);

            // Then
            using (new AssertionScope())
            {
                result.Substantive.SubstantiveType.Should().Be(expectedWordType);

                result.Substantive.SingleNominativObestamd.Should().Be(conjugations[0]);
                result.Substantive.SingleNominativBestamd.Should().Be(conjugations[1]);
                result.Substantive.PluralNominativObestamd.Should().Be(conjugations[2]);
                result.Substantive.PluralNominativBestamd.Should().Be(conjugations[3]);
                result.Substantive.SingleGenitivObestamd.Should().Be(conjugations[4]);
                result.Substantive.SingleGenitivBestamd.Should().Be(conjugations[5]);
                result.Substantive.PluralGenitivObestamd.Should().Be(conjugations[6]);
                result.Substantive.PluralGenitivBestamd.Should().Be(conjugations[7]);
            }

        }

        [Test]
        public void FromString_InvalidInput_ShouldThrow()
        {
            // Given
            var wordType = "utrum";
            var conjugations = new[] { "just one will fail" };

            // When
            Action act = () => WordResultMapper.ToWordResult(wordType, conjugations);

            // Then
            act.Should().Throw<WordResultMapperException>().WithMessage("Error while mapping WordResult");
        }
    }
}