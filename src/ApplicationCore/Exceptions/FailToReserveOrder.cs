using System;

namespace Microsoft.eShopWeb.ApplicationCore.Exceptions
{
    public class FailToReserveOrder : Exception
    {
        public FailToReserveOrder(int buyerId) : base($"Failed to reserve order for buyer: {buyerId}")
        {
        }

        protected FailToReserveOrder(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public FailToReserveOrder(string message) : base(message)
        {
        }

        public FailToReserveOrder(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
