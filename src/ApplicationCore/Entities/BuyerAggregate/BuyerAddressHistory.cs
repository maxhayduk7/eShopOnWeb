using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate
{
    public class BuyerAddressHistory : BaseEntity, IAggregateRoot
    {
        public Address PreviousAddress { get; set; }
        public int BuyerAddressId { get; set; }
    }
}
