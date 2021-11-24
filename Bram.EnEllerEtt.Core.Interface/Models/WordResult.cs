namespace Bram.EnEllerEtt.Core.Interface.Models
{
    public class WordResult
    {
        public SubstantiveResult Substantive { get; set; }
        public VerbResult Verb { get; set; }

        public override string ToString()
        {
            if (Substantive != null && Verb != null)
            {
                return $"{Substantive}\r\n{Verb}";
            }
            if (Substantive != null)
            {
                return Substantive.ToString();
            }
            if (Verb != null)
            {
                return Verb.ToString();
            }
            return "Word not found!";
        }
    }
}
