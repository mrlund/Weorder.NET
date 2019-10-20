using System.Threading.Tasks;
using Weorder.NET.Entities;

namespace Weorder.NET.Interfaces
{
    public interface ITableSessionsClient
    {
        Task<WeorderApiResponse<TableSession>> Checkout(string integrationId, string tableSessionId);
        Task<WeorderApiResponse<TableSession>> ConfirmPayment(string integrationId, string tableSessionId);
        Task<WeorderApiResponse<TableSession>> Get(string integrationId, string tableSessionId);
        Task<WeorderApiResponse<TableSession>> Uncheckout(string integrationId, string tableSessionId);
    }
}