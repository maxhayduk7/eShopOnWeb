using Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.BuyerTests
{
    public class BuyerAddress_UpdateAddress
    {
        private int _testBuyerId = 123;
        private string _testStreet1 = nameof(_testStreet1);
        private string _testStreet2 = nameof(_testStreet2);
        private string _testCity = nameof(_testCity);
        private string _testState = nameof(_testState);
        private string _testZipCode = nameof(_testZipCode);

        [Fact]
        public void SetsValuesAsExpected()
        {
            var buyerAddress = new BuyerAddress(_testBuyerId);
            var address = new Address(_testStreet1, _testStreet2, _testCity, _testState, _testZipCode);
            buyerAddress.UpdateAddress(address);

            Assert.Equal(address, buyerAddress.Address);

            var anotherAddress = new Address(_testStreet1, _testStreet2, _testCity, _testState, _testZipCode);
            Assert.Equal(anotherAddress, buyerAddress.Address);
        }

        [Fact]
        public void VerifiesWithAllRequiredFields()
        {
            var buyerAddress = new BuyerAddress(_testBuyerId);
            var address = new Address(_testStreet1, _testStreet2, _testCity, _testState, _testZipCode);
            buyerAddress.UpdateAddress(address);

            Assert.Equal("Verified", buyerAddress.AddressVerified);
        }

        [Fact]
        public void VerifiesMissingStreet1Field()
        {
            var buyerAddress = new BuyerAddress(_testBuyerId);
            var address = new Address("", _testStreet2, _testCity, _testState, _testZipCode);
            buyerAddress.UpdateAddress(address);

            Assert.Equal("Missing Field: Street1", buyerAddress.AddressVerified);
        }

        [Fact]
        public void VerifiesZipCodeStateMismatchField()
        {
            var buyerAddress = new BuyerAddress(_testBuyerId);
            var address = new Address(_testStreet1, _testStreet2, _testCity, "OH", "12345");
            buyerAddress.UpdateAddress(address);

            Assert.Equal("Invalid State-ZipCode combination", buyerAddress.AddressVerified);
        }
    }
}
