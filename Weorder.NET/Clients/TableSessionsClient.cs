using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weorder.NET.Entities;
using Weorder.NET.Interfaces;
using Weorder.NET.Utilities;

namespace Weorder.NET.Clients
{
    public class TableSessionsClient : ITableSessionsClient
    {
        private readonly WeorderClientBase _client;

        public TableSessionsClient(WeorderClientBase client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<WeorderApiResponse<TableSession>> Get(string integrationId, string tableSessionId)
        {
            return await _client.MakeApiRequest<TableSession>($"integrations/{integrationId}/table-sessions/{tableSessionId}");
        }
        public async Task<WeorderApiResponse<TableSession>> Checkout(string integrationId, string tableSessionId)
        {
            return await _client.MakeApiRequest<TableSession>($"integrations/{integrationId}/table-sessions/{tableSessionId}/checkout", RequestMethod.PATCH);
        }
        public async Task<WeorderApiResponse<TableSession>> Uncheckout(string integrationId, string tableSessionId)
        {
            return await _client.MakeApiRequest<TableSession>($"integrations/{integrationId}/table-sessions/{tableSessionId}/uncheckout", RequestMethod.PATCH);
        }
        public async Task<WeorderApiResponse<TableSession>> ConfirmPayment(string integrationId, string tableSessionId)
        {
            return await _client.MakeApiRequest<TableSession>($"integrations/{integrationId}/table-sessions/{tableSessionId}/payment/confirm", RequestMethod.PUT);
        }
    }
}
