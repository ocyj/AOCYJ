using System;
using System.Runtime.Serialization;

namespace Common
{
    [Serializable]
    internal class MagicSmokeException : Exception
    {
        public MagicSmokeException()
        {
        }

        public MagicSmokeException(string message) : base(message)
        {
        }

        public MagicSmokeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MagicSmokeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}