using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Weorder.NET.Interfaces;
using Weorder.NET.Utilities;

namespace Weorder.NET.Clients
{
    public class WeorderOrderingClient : WeorderClientBase, IWeorderOrderingClient
    {
        private readonly IIntegrationsClient _integrationsClient;
        private readonly IOrdersClient _ordersClient;
        private readonly IInventoryClient _inventoryClient;
        private readonly ITableSessionsClient _tableSessionsClient;

        public IIntegrationsClient Integrations => _integrationsClient;
        public IOrdersClient Orders => _ordersClient;
        public IInventoryClient Inventory => _inventoryClient;
        public ITableSessionsClient TableSessions => _tableSessionsClient;


        public WeorderOrderingClient(HttpClient httpClient,
                                string accessToken = null,
                                ILoggerFactory loggerFactory = null,
                                TargetEnvironment environment = TargetEnvironment.STAGING) : base(httpClient, accessToken, loggerFactory)
        {
            SetBaseUri(environment == TargetEnvironment.PRODUCTION ? OrderingUrls.PRODUCTION : environment == TargetEnvironment.STAGING ? OrderingUrls.STAGING : OrderingUrls.QA);
            
            _integrationsClient = new IntegrationsClient(this);
            _ordersClient = new OrdersClient(this);
            _inventoryClient = new InventoryClient(this);
            _tableSessionsClient = new TableSessionsClient(this); 

        }
    }
}
