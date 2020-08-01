using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TTH.MonkBlog.StudyHistories;

namespace TTH.MonkBlog.Controllers.StudyHistories
{
    [RemoteService]
    [Area("app")]
    [ControllerName("StudyHistory")]
    [Route("api/app/studyHistory")]
    public class StudyHistoryController : AbpController, IStudyHistoryAppService
    {
        private readonly IStudyHistoryAppService _studyHistoryAppService;

        public StudyHistoryController(IStudyHistoryAppService studyHistoryAppService)
        {
            _studyHistoryAppService = studyHistoryAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<StudyHistoryDto>> GetListAsync(GetStudyHistoriesInput input)
        {
            return _studyHistoryAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<StudyHistoryDto> GetAsync(Guid id)
        {
            return _studyHistoryAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<StudyHistoryDto> CreateAsync(StudyHistoryCreateDto input)
        {
            return _studyHistoryAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<StudyHistoryDto> UpdateAsync(Guid id, StudyHistoryUpdateDto input)
        {
            return _studyHistoryAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _studyHistoryAppService.DeleteAsync(id);
        }
    }
}