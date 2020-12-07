using System;
using System.Runtime.Serialization;

namespace Microsoft.eShopWeb.ApplicationCore.Exceptions
{
    [Serializable]
    internal class DuplicateAddressException : Exception
    {
        public DuplicateAddressException() : base("The address specified already exists for this Buyer.")
        {
        }

        public DuplicateAddressException(string message) : base(message)
        {
        }

        public DuplicateAddressException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}