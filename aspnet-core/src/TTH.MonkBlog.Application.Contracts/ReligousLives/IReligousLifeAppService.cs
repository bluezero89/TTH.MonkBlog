using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TTH.MonkBlog.ReligousLives
{
    public interface IReligousLifeAppService : IApplicationService
    {
        Task<PagedResultDto<ReligousLifeDto>> GetListAsync(GetReligousLivesInput input);

        Task<ReligousLifeDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ReligousLifeDto> CreateAsync(ReligousLifeCreateDto input);

        Task<ReligousLifeDto> UpdateAsync(Guid id, ReligousLifeUpdateDto input);
    }
}