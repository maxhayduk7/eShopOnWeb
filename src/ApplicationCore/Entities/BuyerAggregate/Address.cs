using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate
{
    public class Address : ValueObject
    {
        public string Street1 { get; private set; }
        public string Street2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public Address(string street1, string street2, string city, string state, string zipCode)
        {
            Street1 = street1;
            Street2 = street2;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        private Address()
        {
            // Required for EF
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street1;
            yield return Street2;
            yield return City;
            yield return State;
            yield return ZipCode;
        }
    }
}
