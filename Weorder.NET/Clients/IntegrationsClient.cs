using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weorder.NET.Entities;
using Weorder.NET.Interfaces;
using Weorder.NET.Utilities;

namespace Weorder.NET.Clients
{
    public class IntegrationsClient : IIntegrationsClient
    {
        private readonly WeorderClientBase _client;

        public IntegrationsClient(WeorderClientBase client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<WeorderApiResponse<List<Integration>>> Get()
        {
            return await _client.MakeApiRequest<List<Integration>>($"integrations");
        }

        public async Task<WeorderApiResponse<Integration>> Get(string integrationId)
        {
            return await _client.MakeApiRequest<Integration>($"integrations/{integrationId}");
        }
        public async Task<WeorderApiResponse<Integration>> Create(Integration integration)
        {
            return await _client.MakeApiRequest<Integration>($"integrations/{integration.id}", RequestMethod.POST, integration);
        }
        public async Task<WeorderApiResponse<Integration>> Update(Integration integration)
        {
            return await _client.MakeApiRequest<Integration>($"integrations/{integration.id}", RequestMethod.PATCH, integration);
        }
        public async Task<WeorderApiResponse<Integration>> Refresh(string integrationId)
        {
            return await _client.MakeApiRequest<Integration>($"integrations/{integrationId}/refresh");
        }
        public async Task<WeorderApiResponse<Integration>> Enable(string integrationId)
        {
            return await _client.MakeApiRequest<Integration>($"integrations/{integrationId}/enable", RequestMethod.PATCH);
        }
        public async Task<WeorderApiResponse<Integration>> Disable(string integrationId)
        {
            return await _client.MakeApiRequest<Integration>($"integrations/{integrationId}/disable", RequestMethod.PATCH);
        }

    }
}
