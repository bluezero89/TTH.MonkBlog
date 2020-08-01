using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using TTH.MonkBlog.Pastorals;

namespace TTH.MonkBlog.Controllers.Pastorals
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Pastoral")]
    [Route("api/app/pastoral")]
    public class PastoralController : AbpController, IPastoralAppService
    {
        private readonly IPastoralAppService _pastoralAppService;

        public PastoralController(IPastoralAppService pastoralAppService)
        {
            _pastoralAppService = pastoralAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<PastoralDto>> GetListAsync(GetPastoralsInput input)
        {
            return _pastoralAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<PastoralDto> GetAsync(Guid id)
        {
            return _pastoralAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<PastoralDto> CreateAsync(PastoralCreateDto input)
        {
            return _pastoralAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<PastoralDto> UpdateAsync(Guid id, PastoralUpdateDto input)
        {
            return _pastoralAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _pastoralAppService.DeleteAsync(id);
        }
    }
}