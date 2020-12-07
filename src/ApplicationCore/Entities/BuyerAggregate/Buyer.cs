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

        public string Street1 { get; private set; }
        public string Street2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string AddressVerified { get; private set; } = string.Empty;

        public void UpdateAddress(string street1, string street2, string city, string state, string zipCode)
        {
            AddressVerified = VerifyAddress(street1, street2, city, state, zipCode);

            Street1 = street1;
            Street2 = street2;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        private string VerifyAddress(string street1, string street2, string city, string state, string zipCode)
        {
            string missing = "Missing Field: ";
            if (string.IsNullOrEmpty(street1)) return missing + nameof(Street1);
            if (string.IsNullOrEmpty(city)) return missing + nameof(City);
            if (string.IsNullOrEmpty(state)) return missing + nameof(State);
            if (string.IsNullOrEmpty(zipCode)) return missing + nameof(ZipCode);

            string mismatch = "Invalid State-ZipCode combination";
            if (state != "NY" && zipCode == "12345") return mismatch;
            if (state != "OH" && zipCode == "44240") return mismatch;

            return "Verified";
        }
    }
}
