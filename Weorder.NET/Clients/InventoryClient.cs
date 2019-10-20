using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weorder.NET.Entities;
using Weorder.NET.Interfaces;

namespace Weorder.NET.Clients
{
    public class InventoryClient : IInventoryClient
    {
        private readonly WeorderClientBase _client;

        public InventoryClient(WeorderClientBase client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<WeorderApiResponse<Inventory>> Get(string integrationId, string inventoryId)
        {
            return await _client.MakeApiRequest<Inventory>($"integrations/{integrationId}/inventories/{inventoryId}");
        }


    }
}
