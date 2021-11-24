namespace Bram.EnEllerEtt.Core.Interface.Models
{
    public class VerbResult
    {
        public string Infinitiv { get; set; }
        public string Presens { get; set; }
        public string Preteritum { get; set; }
        public string Supinum { get; set; }
        public string Imperativ { get; set; }

        public override string ToString()
        {
            return $"{Infinitiv}, {Presens}, {Preteritum}, {Supinum}, {Imperativ}";
        }
    }
}
