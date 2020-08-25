using System.Threading.Tasks;
using Abp.Application.Services;
using MyCouldBook.Sessions.Dto;

namespace MyCouldBook.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
