using Bram.EnEllerEtt.Core.Interface.Models;
using System;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.Mapper
{
    public static class SubstantiveTypeMapper
    {
        public static SubstantiveType FromString(string input)
        {
            var inputLowercased = input.ToLower();
            if (inputLowercased.Equals("utrum"))
            {
                return SubstantiveType.En;
            }

            if (inputLowercased.Equals("neutrum"))
            {
                return SubstantiveType.Ett;
            }

            throw new ArgumentOutOfRangeException(nameof(input), input, $"Cannot map '{input}' to {nameof(SubstantiveType)}");
        }
    }
}