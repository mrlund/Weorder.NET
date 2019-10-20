using System.Threading.Tasks;
using Weorder.NET.Entities;

namespace Weorder.NET.Interfaces

{
    public interface IInventoryClient
    {
        Task<WeorderApiResponse<Inventory>> Get(string integrationId, string inventoryId);
    }
}