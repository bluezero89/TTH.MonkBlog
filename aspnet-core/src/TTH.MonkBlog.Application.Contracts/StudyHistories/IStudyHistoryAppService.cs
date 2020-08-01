using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TTH.MonkBlog.StudyHistories
{
    public interface IStudyHistoryAppService : IApplicationService
    {
        Task<PagedResultDto<StudyHistoryDto>> GetListAsync(GetStudyHistoriesInput input);

        Task<StudyHistoryDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<StudyHistoryDto> CreateAsync(StudyHistoryCreateDto input);

        Task<StudyHistoryDto> UpdateAsync(Guid id, StudyHistoryUpdateDto input);
    }
}