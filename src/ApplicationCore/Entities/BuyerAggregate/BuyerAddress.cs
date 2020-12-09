namespace Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate
{
    public class BuyerAddress : BaseEntity
    {
        public int BuyerId { get; private set; }
        public Address Address { get; private set; }
        public string AddressVerified { get; private set; } = string.Empty;

        public BuyerAddress(int buyerId)
        {
            BuyerId = buyerId;
        }

        private BuyerAddress()
        {
            // Required for EF
        }

        public void UpdateAddress(Address address)
        {
            if (Address == address) return;

            var updatedEvent = new BuyerAddressUpdatedEvent(buyerAddressId: Id, previousValue: Address, newValue: address);
            Events.Add(updatedEvent);

            AddressVerified = VerifyAddress(address);

            Address = address;
        }

        private string VerifyAddress(Address address)
        {
            string missing = "Missing Field: ";
            if (string.IsNullOrEmpty(address.Street1)) return missing + nameof(address.Street1);
            if (string.IsNullOrEmpty(address.City)) return missing + nameof(address.City);
            if (string.IsNullOrEmpty(address.State)) return missing + nameof(address.State);
            if (string.IsNullOrEmpty(address.ZipCode)) return missing + nameof(address.ZipCode);

            string mismatch = "Invalid State-ZipCode combination";
            if (address.State != "NY" && address.ZipCode == "12345") return mismatch;
            if (address.State != "OH" && address.ZipCode == "44240") return mismatch;

            return "Verified";
        }
    }
}
