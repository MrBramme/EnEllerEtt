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
            var expectedWordType = WordTypeMapper.FromString(wordType);

            // When
            var result = WordResultMapper.ToWordResult(wordType, conjugations);

            // Then
            using (new AssertionScope())
            {
                result.WordType.Should().Be(expectedWordType);

                result.SingleNominativObestämd.Should().Be(conjugations[0]);
                result.SingleNominativBestämd.Should().Be(conjugations[1]);
                result.PluralNominativObestämd.Should().Be(conjugations[2]);
                result.PluralNominativBestämd.Should().Be(conjugations[3]);
                result.SingleGenitivObestämd.Should().Be(conjugations[4]);
                result.SingleGenitivBestämd.Should().Be(conjugations[5]);
                result.PluralGenitivObestämd.Should().Be(conjugations[6]);
                result.PluralGenitivBestämd.Should().Be(conjugations[7]);
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