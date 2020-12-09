namespace Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate
{
    public class BuyerAddressUpdatedEvent : BaseDomainEvent
    {
        public BuyerAddressUpdatedEvent(int buyerAddressId, Address previousValue, Address newValue)
        {
            BuyerAddressId = buyerAddressId;
            PreviousValue = previousValue;
            NewValue = newValue;
        }

        public int BuyerAddressId { get; }
        public Address PreviousValue { get; }
        public Address NewValue { get; }
    }
}