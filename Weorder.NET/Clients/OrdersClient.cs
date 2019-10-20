using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weorder.NET.Entities;
using Weorder.NET.Interfaces;
using Weorder.NET.Utilities;

namespace Weorder.NET.Clients
{
    public class OrdersClient : IOrdersClient
    {
        private readonly WeorderClientBase _client;

        public OrdersClient(WeorderClientBase client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<WeorderApiResponse<Order>> Create(string integrationId, Order order)
        {
            return await _client.MakeApiRequest<Order>($"integrations/{integrationId}/orders", RequestMethod.POST, order);
        }
        public async Task<WeorderApiResponse<Order>> Cancel(string integrationId, string orderId)
        {
            return await _client.MakeApiRequest<Order>($"integrations/{integrationId}/orders/{orderId}/cancel", RequestMethod.PATCH);
        }
    }
}
