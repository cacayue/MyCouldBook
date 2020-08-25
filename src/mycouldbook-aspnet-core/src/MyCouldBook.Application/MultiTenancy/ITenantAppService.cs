using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCouldBook.MultiTenancy.Dto;

namespace MyCouldBook.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

