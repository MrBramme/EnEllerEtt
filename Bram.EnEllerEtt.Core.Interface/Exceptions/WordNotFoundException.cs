using System;

namespace Bram.EnEllerEtt.Core.Interface.Exceptions
{
    public class WordNotFoundException : Exception
    {
        public WordNotFoundException(string message)
            : base(message)
        {
        }
    }
}
