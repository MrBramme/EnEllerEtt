using System;

namespace Bram.EnEllerEtt.Core.Interface.Exceptions
{
    public class WordResultMapperException : Exception
    {
        public WordResultMapperException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
