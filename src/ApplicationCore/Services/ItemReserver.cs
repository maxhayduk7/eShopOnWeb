using Azure.Messaging.ServiceBus;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Exceptions;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class ItemReserver : IItemReserver
    {
        private IConfiguration configuration;

        private string connectionString;

        private string queueName;

        private ServiceBusClient client;

        private ServiceBusSender sender;

        public ItemReserver(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration["ServiceBus"];
            queueName = this.configuration["ReservedOrders"];
        }

        public async Task ReserveItemsAsync(IEnumerable<OrderItem> items)
        {
            client = new ServiceBusClient(connectionString);
            sender = client.CreateSender(queueName);

            var jsonString = JsonConvert.SerializeObject(items);

            try
            {
                await sender.SendMessageAsync(new ServiceBusMessage(jsonString));
            }
            catch (Exception ex)
            {
                throw new FailToReserveOrder($"Failed to reserve orders", ex);
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}
