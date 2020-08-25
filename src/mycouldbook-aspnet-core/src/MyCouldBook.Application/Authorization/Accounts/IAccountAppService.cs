using System.Threading.Tasks;
using Abp.Application.Services;
using MyCouldBook.Authorization.Accounts.Dto;

namespace MyCouldBook.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
