using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TTH.MonkBlog.ReligousLives;

namespace TTH.MonkBlog.Controllers.ReligousLives
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ReligousLife")]
    [Route("api/app/religousLife")]
    public class ReligousLifeController : AbpController, IReligousLifeAppService
    {
        private readonly IReligousLifeAppService _religousLifeAppService;

        public ReligousLifeController(IReligousLifeAppService religousLifeAppService)
        {
            _religousLifeAppService = religousLifeAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ReligousLifeDto>> GetListAsync(GetReligousLivesInput input)
        {
            return _religousLifeAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ReligousLifeDto> GetAsync(Guid id)
        {
            return _religousLifeAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ReligousLifeDto> CreateAsync(ReligousLifeCreateDto input)
        {
            return _religousLifeAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ReligousLifeDto> UpdateAsync(Guid id, ReligousLifeUpdateDto input)
        {
            return _religousLifeAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _religousLifeAppService.DeleteAsync(id);
        }
    }
}