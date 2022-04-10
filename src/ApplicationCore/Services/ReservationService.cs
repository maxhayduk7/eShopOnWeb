using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Exceptions;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    // TODO: Refactor class, use async scenario
    public class ReservationService : IReservationService
    {
        private string url = Environment.GetEnvironmentVariable("AzureFunction");

        public void Reserve(Order order)
        {
            var responce = ReserveOrder(order);

            if (responce.StatusCode is not HttpStatusCode.OK)
            {
                throw new FailToReserveOrder(order.BuyerId);
            }
        }

        private HttpWebResponse ReserveOrder(Order order)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";

            var reservedOrder = PrepareReservedOrder(order);

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(reservedOrder);

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

            return httpResponse;
        }

        private OrderReserved PrepareReservedOrder(Order order)
            => new OrderReserved
            (
                order.BuyerId,
                order.ShipToAddress,
                order.OrderItems.Select(o => new OrderItemReserved
                                            (
                                                o.ItemOrdered.CatalogItemId,
                                                o.ItemOrdered.ProductName,
                                                o.Units
                                             )),
                order.Total()
            );
    }
}
