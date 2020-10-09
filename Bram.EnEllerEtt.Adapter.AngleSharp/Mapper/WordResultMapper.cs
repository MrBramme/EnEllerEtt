using Bram.EnEllerEtt.Core.Interface.Models;

namespace Bram.EnEllerEtt.Adapter.AngleSharp.Mapper
{
    public static class WordResultMapper
    {
        public static WordResult ToWordResult(string type, string[] conjugations)
        {
            return new WordResult
            {
                WordType = WordTypeMapper.FromString(type),
                SingleNominativObestämd = conjugations[0],
                SingleNominativBestämd = conjugations[1],
                PluralNominativObestämd = conjugations[2],
                PluralNominativBestämd = conjugations[3],
                SingleGenitivObestämd = conjugations[4],
                SingleGenitivBestämd = conjugations[5],
                PluralGenitivObestämd = conjugations[6],
                PluralGenitivBestämd = conjugations[7],
            };
        }
    }
}
