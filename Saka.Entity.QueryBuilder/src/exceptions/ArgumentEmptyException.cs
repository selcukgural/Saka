namespace Saka.Entity.QueryBuilder.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    public class ArgumentEmptyException : Exception
    {
        public ArgumentEmptyException()
        {
        }

        public ArgumentEmptyException(string message) : base(message)
        {
        }

        public ArgumentEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArgumentEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
