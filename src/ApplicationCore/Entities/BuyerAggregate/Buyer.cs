using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate
{
    public class Buyer : BaseEntity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }

        private List<PaymentMethod> _paymentMethods = new List<PaymentMethod>();

        public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

        private Buyer()
        {
            // required by EF
        }

        public Buyer(string identity) : this()
        {
            Guard.Against.NullOrEmpty(identity, nameof(identity));
            IdentityGuid = identity;
        }

        public Address Address { get; private set; }
        public string AddressVerified { get; private set; } = string.Empty;

        public void UpdateAddress(Address address)
        {
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
