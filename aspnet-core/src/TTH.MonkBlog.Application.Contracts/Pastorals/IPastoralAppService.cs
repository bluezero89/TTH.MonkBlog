using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TTH.MonkBlog.Pastorals
{
    public interface IPastoralAppService : IApplicationService
    {
        Task<PagedResultDto<PastoralDto>> GetListAsync(GetPastoralsInput input);

        Task<PastoralDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<PastoralDto> CreateAsync(PastoralCreateDto input);

        Task<PastoralDto> UpdateAsync(Guid id, PastoralUpdateDto input);
    }
}