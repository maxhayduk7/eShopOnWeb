using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
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

        public void UpdateAddress(string street1, string street2, string city, string state, string zipCode)
        {
            // TODO: Validate address
            Street1 = street1;
            Street2 = street2;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}
