using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TTH.MonkBlog.Monks
{
    public interface IMonkAppService : IApplicationService
    {
        Task<PagedResultDto<MonkDto>> GetListAsync(GetMonksInput input);

        Task<MonkDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<MonkDto> CreateAsync(MonkCreateDto input);

        Task<MonkDto> UpdateAsync(Guid id, MonkUpdateDto input);
    }
}