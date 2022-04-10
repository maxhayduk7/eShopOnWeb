using System.Collections.Generic;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate
{
    public class OrderReserved
    {
        public string BuyerId { get; set; }
        public Address ShipToAddress { get; set; }

        public IEnumerable<OrderItemReserved> Items { get; set; }

        public decimal Total { get; set; }

        public OrderReserved(string buyerId, Address shipToAddress, IEnumerable<OrderItemReserved> items, decimal total)
        {
            BuyerId = buyerId;
            ShipToAddress = shipToAddress;
            Items = items;
            Total = total;
        }
    }

    public class OrderItemReserved
    {
        public int CatalogItemId { get; set; }
        public string ProductName { get; set; }
        public int Units { get; set; }

        public OrderItemReserved(int catalogItemId, string productName, int units)
        {
            CatalogItemId = catalogItemId;
            ProductName = productName;
            Units = units;
        }
    }
}
