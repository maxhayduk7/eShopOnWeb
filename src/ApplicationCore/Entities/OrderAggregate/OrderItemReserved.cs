namespace Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate
{
    public class OrderItemReserved
    {
        public int Quantity { get; private set; }
        public int CatalogItemId { get; private set; }

        public OrderItemReserved(int catalogItemId, int quantity)
        {
            catalogItemId = CatalogItemId;
            quantity = Quantity;
        }
    }
}
