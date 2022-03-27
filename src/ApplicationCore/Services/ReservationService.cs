using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class ReservationService : IReservationService
    {
        private string url = Environment.GetEnvironmentVariable("AzureFunction");

        public void ReserveItems(IEnumerable<OrderItem> orderedItems)
            => orderedItems.Select(item => ReserveItem(item));

        private HttpWebResponse ReserveItem(OrderItem orderItem)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(orderItem);

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
    }
}
