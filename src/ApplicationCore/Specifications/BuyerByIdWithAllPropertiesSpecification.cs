using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications
{
    public sealed class BuyerByIdWithAllPropertiesSpecification : Specification<Buyer>
    {
        public BuyerByIdWithAllPropertiesSpecification(int buyerId)
        {
            Query
                .Where(buyer => buyer.Id == buyerId)
                .Include(buyer => buyer.BuyerAddresses);
            Query.Include(buyer => buyer.PaymentMethods);
        }
    }
}
