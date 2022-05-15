using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class OrderDeliverer : IOrderDeliverer
    {
        private IConfiguration configuration;

        private string uri;

        public OrderDeliverer(IConfiguration configuration)
        {
            this.configuration = configuration;
            uri = this.configuration["DeliveryOrderProcessor"];
        }
        public async Task DeliverOrderAsync(Order order)
        {
            OrderForDelivery orderForDelivery = new OrderForDelivery
            {
                BuyerId = order.BuyerId,
                ShipToAddress = order.ShipToAddress,
                Total = order.Total(),

                Items = order.OrderItems.Select(o => new ItemReserved
                {
                    CatalogItemId = o.ItemOrdered.CatalogItemId,
                    ProductName = o.ItemOrdered.ProductName,
                    Units = o.Units
                })
            };

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(orderForDelivery);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, content);
                var respString = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
