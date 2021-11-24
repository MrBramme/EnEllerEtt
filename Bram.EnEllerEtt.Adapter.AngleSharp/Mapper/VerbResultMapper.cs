using Bram.EnEllerEtt.Core.Interface.Exceptions;
using Bram.EnEllerEtt.Core.Interface.Models;
using System;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.Mapper
{
    public static class VerbResultMapper
    {
        public static VerbResult ToVerbResult(string[] conjugations)
        {
            try
            {
                var result = new VerbResult
                {
                    Infinitiv = conjugations[0],
                    Presens = conjugations[2],
                    Preteritum = conjugations[4],
                    Supinum = conjugations[6],
                    Imperativ = conjugations[8]
                };
                return result;
            }
            catch (Exception e)
            {
                throw new VerbResultMapperException("Error while mapping VerbResult", e);
            }
        }
    }
}
