using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TTH.MonkBlog.Monks;

namespace TTH.MonkBlog.Controllers.Monks
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Monk")]
    [Route("api/app/monk")]
    public class MonkController : AbpController, IMonkAppService
    {
        private readonly IMonkAppService _monkAppService;

        public MonkController(IMonkAppService monkAppService)
        {
            _monkAppService = monkAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<MonkDto>> GetListAsync(GetMonksInput input)
        {
            return _monkAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<MonkDto> GetAsync(Guid id)
        {
            return _monkAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<MonkDto> CreateAsync(MonkCreateDto input)
        {
            return _monkAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<MonkDto> UpdateAsync(Guid id, MonkUpdateDto input)
        {
            return _monkAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _monkAppService.DeleteAsync(id);
        }
    }
}