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
using TTH.MonkBlog.Pastorals;

namespace TTH.MonkBlog.Pastorals
{
    [RemoteService(IsEnabled = false)]
    [Authorize(MonkBlogPermissions.Pastorals.Default)]
    public class PastoralAppService : ApplicationService, IPastoralAppService
    {
        private readonly IPastoralRepository _pastoralRepository;

        public PastoralAppService(IPastoralRepository pastoralRepository)
        {
            _pastoralRepository = pastoralRepository;
        }

        public virtual async Task<PagedResultDto<PastoralDto>> GetListAsync(GetPastoralsInput input)
        {
            var totalCount = await _pastoralRepository.GetCountAsync(input.FilterText, input.MonkId, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PlaceOfPastoral);
            var items = await _pastoralRepository.GetListAsync(input.FilterText, input.MonkId, input.FromDateMin, input.FromDateMax, input.ToDateMin, input.ToDateMax, input.PlaceOfPastoral, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PastoralDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Pastoral>, List<PastoralDto>>(items)
            };
        }

        public virtual async Task<PastoralDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Pastoral, PastoralDto>(await _pastoralRepository.GetAsync(id));
        }

        [Authorize(MonkBlogPermissions.Pastorals.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _pastoralRepository.DeleteAsync(id);
        }

        [Authorize(MonkBlogPermissions.Pastorals.Create)]
        public virtual async Task<PastoralDto> CreateAsync(PastoralCreateDto input)
        {
            var pastoral = ObjectMapper.Map<PastoralCreateDto, Pastoral>(input);

            pastoral = await _pastoralRepository.InsertAsync(pastoral, autoSave: true);
            return ObjectMapper.Map<Pastoral, PastoralDto>(pastoral);
        }

        [Authorize(MonkBlogPermissions.Pastorals.Edit)]
        public virtual async Task<PastoralDto> UpdateAsync(Guid id, PastoralUpdateDto input)
        {
            var pastoral = await _pastoralRepository.GetAsync(id);
            ObjectMapper.Map(input, pastoral);
            pastoral = await _pastoralRepository.UpdateAsync(pastoral);
            return ObjectMapper.Map<Pastoral, PastoralDto>(pastoral);
        }
    }
}