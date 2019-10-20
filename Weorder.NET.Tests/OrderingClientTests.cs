using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weorder.NET.Clients;
using Weorder.NET.Entities;
using Xunit;

namespace Weorder.NET.Tests
{
    public class OrderingClientTests
    {
        private readonly HttpClient _httpClient;

        [Fact]
        public void CanInstantiateClient()
        {
            var client = new WeorderOrderingClient(new HttpClient());

            Assert.NotNull(client);
        }
        [Fact]
        public async Task CanDeserializeIntegrationResponse()
        {
            var client = new WeorderOrderingClient(new HttpClient(new FakeHttpMessageHandler<Integration>()));
            var tx = await client.Integrations.Get("");
            Assert.NotNull(tx);
        }

        [Fact]
        public async Task CanDeserializeOrderResponse()
        {
            var client = new WeorderOrderingClient(new HttpClient(new FakeHttpMessageHandler<Order>()));
            var tx = await client.Orders.Create("", new Order());
            Assert.NotNull(tx);
        }

        [Fact]
        public async Task CanDeserializeInventoryResponse()
        {
            var client = new WeorderOrderingClient(new HttpClient(new FakeHttpMessageHandler<Inventory>()));
            var tx = await client.Inventory.Get("", "");
            Assert.NotNull(tx);
        }
        [Fact]
        public async Task CanDeserializeTableSessionResponse()
        {
            var client = new WeorderOrderingClient(new HttpClient(new FakeHttpMessageHandler<TableSession>()));
            var tx = await client.TableSessions.Get("", "");
            Assert.NotNull(tx);
        }
    }
}
