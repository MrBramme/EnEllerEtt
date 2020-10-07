namespace Bram.EnEllerEtt.Core.Interface.Models
{
    public class WordResult
    {
        public WordType WordType { get; set; }
        public string SingleNominativObestämd { get; set; }
        public string SingleNominativBestämd { get; set; }
        public string PluralNominativObestämd { get; set; }
        public string PluralNominativBestämd { get; set; }

        public string SingleGenitivObestämd { get; set; }
        public string SingleGenitivBestämd { get; set; }
        public string PluralGenitivObestämd { get; set; }
        public string PluralGenitivBestämd { get; set; }
    }
}
