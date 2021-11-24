using System;

namespace Bram.EnEllerEtt.Core.Interface.Exceptions
{
    public class VerbResultMapperException : Exception
    {
        public VerbResultMapperException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
