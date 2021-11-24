namespace Bram.EnEllerEtt.Core.Interface.Models
{
    public class SubstantiveResult
    {
        public SubstantiveType SubstantiveType { get; set; }
        public string SingleNominativObestamd { get; set; }
        public string SingleNominativBestamd { get; set; }
        public string PluralNominativObestamd { get; set; }
        public string PluralNominativBestamd { get; set; }

        public string SingleGenitivObestamd { get; set; }
        public string SingleGenitivBestamd { get; set; }
        public string PluralGenitivObestamd { get; set; }
        public string PluralGenitivBestamd { get; set; }

        public override string ToString()
        {
            return $"{SubstantiveType} {SingleNominativObestamd}: {SingleNominativBestamd}, {PluralNominativObestamd}, {PluralNominativBestamd}";
        }
    }
}
