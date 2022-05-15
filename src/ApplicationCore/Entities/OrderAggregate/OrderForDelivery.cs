using System.Collections.Generic;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate
{
    public class OrderForDelivery
    {
        public string BuyerId { get; set; }
        public Address ShipToAddress { get; set; }

        public IEnumerable<ItemReserved> Items { get; set; }

        public decimal Total { get; set; }

        public OrderForDelivery()
        {
        }

        public OrderForDelivery(string buyerId, Address shipToAddress, IEnumerable<ItemReserved> items, decimal total)
        {
            BuyerId = buyerId;
            ShipToAddress = shipToAddress;
            Items = items;
            Total = total;
        }
    }

    public class ItemReserved
    {
        public int CatalogItemId { get; set; }
        public string ProductName { get; set; }
        public int Units { get; set; }

        public ItemReserved()
        {
        }

        public ItemReserved(int catalogItemId, string productName, int units)
        {
            CatalogItemId = catalogItemId;
            ProductName = productName;
            Units = units;
        }
    }
}
