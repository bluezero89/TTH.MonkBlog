using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using TTH.MonkBlog.Permissions;
using TTH.MonkBlog.StudyHistories;

namespace TTH.MonkBlog.StudyHistories
{
    [RemoteService(IsEnabled = false)]
    [Authorize(MonkBlogPermissions.StudyHistories.Default)]
    public class StudyHistoryAppService : ApplicationService, IStudyHistoryAppService
    {
        private readonly IStudyHistoryRepository _studyHistoryRepository;

        public StudyHistoryAppService(IStudyHistoryRepository studyHistoryRepository)
        {
            _studyHistoryRepository = studyHistoryRepository;
        }

        public virtual async Task<PagedResultDto<StudyHistoryDto>> GetListAsync(GetStudyHistoriesInput input)
        {
            var totalCount = await _studyHistoryRepository.GetCountAsync(input.FilterText, input.Diploma, input.AcademicLevel, input.StudyAt, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.Achievements);
            var items = await _studyHistoryRepository.GetListAsync(input.FilterText, input.Diploma, input.AcademicLevel, input.StudyAt, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.Achievements, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<StudyHistoryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<StudyHistory>, List<StudyHistoryDto>>(items)
            };
        }

        public virtual async Task<StudyHistoryDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<StudyHistory, StudyHistoryDto>(await _studyHistoryRepository.GetAsync(id));
        }

        [Authorize(MonkBlogPermissions.StudyHistories.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _studyHistoryRepository.DeleteAsync(id);
        }

        [Authorize(MonkBlogPermissions.StudyHistories.Create)]
        public virtual async Task<StudyHistoryDto> CreateAsync(StudyHistoryCreateDto input)
        {
            var studyHistory = ObjectMapper.Map<StudyHistoryCreateDto, StudyHistory>(input);

            studyHistory = await _studyHistoryRepository.InsertAsync(studyHistory, autoSave: true);
            return ObjectMapper.Map<StudyHistory, StudyHistoryDto>(studyHistory);
        }

        [Authorize(MonkBlogPermissions.StudyHistories.Edit)]
        public virtual async Task<StudyHistoryDto> UpdateAsync(Guid id, StudyHistoryUpdateDto input)
        {
            var studyHistory = await _studyHistoryRepository.GetAsync(id);
            ObjectMapper.Map(input, studyHistory);
            studyHistory = await _studyHistoryRepository.UpdateAsync(studyHistory);
            return ObjectMapper.Map<StudyHistory, StudyHistoryDto>(studyHistory);
        }
    }
}