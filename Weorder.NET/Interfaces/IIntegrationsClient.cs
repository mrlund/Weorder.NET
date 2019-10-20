using System.Collections.Generic;
using System.Threading.Tasks;
using Weorder.NET.Entities;

namespace Weorder.NET.Interfaces
{
    public interface IIntegrationsClient
    {
        Task<WeorderApiResponse<Integration>> Create(Integration integration);
        Task<WeorderApiResponse<Integration>> Disable(string integrationId);
        Task<WeorderApiResponse<Integration>> Enable(string integrationId);
        Task<WeorderApiResponse<List<Integration>>> Get();
        Task<WeorderApiResponse<Integration>> Get(string integrationId);
        Task<WeorderApiResponse<Integration>> Refresh(string integrationId);
        Task<WeorderApiResponse<Integration>> Update(Integration integration);
    }
}