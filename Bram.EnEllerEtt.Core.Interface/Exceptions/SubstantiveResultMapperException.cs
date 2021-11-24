using System;

namespace Bram.EnEllerEtt.Core.Interface.Exceptions
{
    public class SubstantiveResultMapperException : Exception
    {
        public SubstantiveResultMapperException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
