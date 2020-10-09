using System;
using Bram.EnEllerEtt.Core.Interface.Models;

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

            throw new ArgumentOutOfRangeException($"Cannot map '{input}' to {nameof(WordType)}");
        }
    }
}