using Weorder.NET.Interfaces;

namespace Weorder.NET.Interfaces
{
    public interface IWeorderOrderingClient
    {
        IIntegrationsClient Integrations { get; }
        IOrdersClient Orders { get; }
        IInventoryClient Inventory { get; }
        ITableSessionsClient TableSessions { get; }
    }
}