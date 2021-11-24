using Bram.EnEllerEtt.Core.Interface.Exceptions;
using Bram.EnEllerEtt.Core.Interface.Models;
using System;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.Mapper
{
    public static class SubstantiveResultMapper
    {
        public static SubstantiveResult ToSubstantiveResult(string substantivType, string[] conjugations)
        {
            try
            {
                var result = new SubstantiveResult
                {
                    SubstantiveType = SubstantiveTypeMapper.FromString(substantivType),
                    SingleNominativObestamd = conjugations[0],
                    SingleNominativBestamd = conjugations[1],
                    PluralNominativObestamd = conjugations[2],
                    PluralNominativBestamd = conjugations[3],
                    SingleGenitivObestamd = conjugations[4],
                    SingleGenitivBestamd = conjugations[5],
                    PluralGenitivObestamd = conjugations[6],
                    PluralGenitivBestamd = conjugations[7],
                };
                return result;
            }
            catch (Exception e)
            {
                throw new SubstantiveResultMapperException("Error while mapping SubstantiveResult", e);
            }
        }
    }
}
