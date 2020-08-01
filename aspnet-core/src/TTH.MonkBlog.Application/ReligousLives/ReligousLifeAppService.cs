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
using TTH.MonkBlog.ReligousLives;

namespace TTH.MonkBlog.ReligousLives
{
    [RemoteService(IsEnabled = false)]
    [Authorize(MonkBlogPermissions.ReligousLives.Default)]
    public class ReligousLifeAppService : ApplicationService, IReligousLifeAppService
    {
        private readonly IReligousLifeRepository _religousLifeRepository;

        public ReligousLifeAppService(IReligousLifeRepository religousLifeRepository)
        {
            _religousLifeRepository = religousLifeRepository;
        }

        public virtual async Task<PagedResultDto<ReligousLifeDto>> GetListAsync(GetReligousLivesInput input)
        {
            var totalCount = await _religousLifeRepository.GetCountAsync(input.FilterText, input.MonkId, input.DateOfPractitionersMin, input.DateOfPractitionersMax, input.DateOfThinhVienMin, input.DateOfThinhVienMax, input.DateOfTapVien, input.FirstKhan, input.SecondKhanMin, input.SecondKhanMax, input.ThirdKhanMin, input.ThirdKhanMax, input.RemainKhanMin, input.RemainKhanMax, input.LifeTimeKhanMin, input.LifeTimeKhanMax, input.DateOfDeaconMin, input.DateOfDeaconMax, input.DateOfPriestMin, input.DateOfPriestMax);
            var items = await _religousLifeRepository.GetListAsync(input.FilterText, input.MonkId, input.DateOfPractitionersMin, input.DateOfPractitionersMax, input.DateOfThinhVienMin, input.DateOfThinhVienMax, input.DateOfTapVien, input.FirstKhan, input.SecondKhanMin, input.SecondKhanMax, input.ThirdKhanMin, input.ThirdKhanMax, input.RemainKhanMin, input.RemainKhanMax, input.LifeTimeKhanMin, input.LifeTimeKhanMax, input.DateOfDeaconMin, input.DateOfDeaconMax, input.DateOfPriestMin, input.DateOfPriestMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ReligousLifeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ReligousLife>, List<ReligousLifeDto>>(items)
            };
        }

        public virtual async Task<ReligousLifeDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ReligousLife, ReligousLifeDto>(await _religousLifeRepository.GetAsync(id));
        }

        [Authorize(MonkBlogPermissions.ReligousLives.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _religousLifeRepository.DeleteAsync(id);
        }

        [Authorize(MonkBlogPermissions.ReligousLives.Create)]
        public virtual async Task<ReligousLifeDto> CreateAsync(ReligousLifeCreateDto input)
        {
            var religousLife = ObjectMapper.Map<ReligousLifeCreateDto, ReligousLife>(input);

            religousLife = await _religousLifeRepository.InsertAsync(religousLife, autoSave: true);
            return ObjectMapper.Map<ReligousLife, ReligousLifeDto>(religousLife);
        }

        [Authorize(MonkBlogPermissions.ReligousLives.Edit)]
        public virtual async Task<ReligousLifeDto> UpdateAsync(Guid id, ReligousLifeUpdateDto input)
        {
            var religousLife = await _religousLifeRepository.GetAsync(id);
            ObjectMapper.Map(input, religousLife);
            religousLife = await _religousLifeRepository.UpdateAsync(religousLife);
            return ObjectMapper.Map<ReligousLife, ReligousLifeDto>(religousLife);
        }
    }
}