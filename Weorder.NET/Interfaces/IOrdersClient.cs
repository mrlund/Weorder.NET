using System.Threading.Tasks;
using Weorder.NET.Entities;

namespace Weorder.NET.Interfaces
{
    public interface IOrdersClient
    {
        Task<WeorderApiResponse<Order>> Cancel(string integrationId, string orderId);
        Task<WeorderApiResponse<Order>> Create(string integrationId, Order order);
    }
}