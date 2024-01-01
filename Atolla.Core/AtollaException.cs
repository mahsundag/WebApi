using System;
using System.Runtime.Serialization;

namespace Atolla.Core
{
    [Serializable]
    public class AtollaException : Exception
    {
        public AtollaException()
        {
        }

        public AtollaException(string message)
            : base(message)
        {
        }

        public AtollaException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {
        }

        protected AtollaException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public AtollaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
