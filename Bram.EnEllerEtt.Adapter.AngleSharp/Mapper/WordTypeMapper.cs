using Bram.EnEllerEtt.Core.Interface.Models;
using System;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.Mapper
{
    public static class WordTypeMapper
    {
        public static WordType FromString(string input)
        {
            var inputLowercased = input.ToLower();
            if (inputLowercased.Equals("utrum"))
            {
                return WordType.En;
            }

            if (inputLowercased.Equals("neutrum"))
            {
                return WordType.Ett;
            }

            throw new ArgumentOutOfRangeException(nameof(input), input, $"Cannot map '{input}' to {nameof(WordType)}");
        }
    }
}