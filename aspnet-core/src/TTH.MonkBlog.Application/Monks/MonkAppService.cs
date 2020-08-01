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
using TTH.MonkBlog.Monks;

namespace TTH.MonkBlog.Monks
{
    [RemoteService(IsEnabled = false)]
    [Authorize(MonkBlogPermissions.Monks.Default)]
    public class MonkAppService : ApplicationService, IMonkAppService
    {
        private readonly IMonkRepository _monkRepository;

        public MonkAppService(IMonkRepository monkRepository)
        {
            _monkRepository = monkRepository;
        }

        public virtual async Task<PagedResultDto<MonkDto>> GetListAsync(GetMonksInput input)
        {
            var totalCount = await _monkRepository.GetCountAsync(input.FilterText, input.ImgPath, input.FullName, input.HolyName, input.HomeTown, input.PermanentAdress, input.DateOfBirthMin, input.DateOfBirthMax, input.DateOfBaptismMin, input.DateOfBaptismMax, input.PlaceOfBaptism, input.DateOfConfirmationMin, input.DateOfConfirmationMax, input.PlaceOfConfirmation, input.Email, input.PhoneNumber, input.Father_FullName, input.Father_HolyName, input.Mother_FullName, input.Mother_HolyName);
            var items = await _monkRepository.GetListAsync(input.FilterText, input.ImgPath, input.FullName, input.HolyName, input.HomeTown, input.PermanentAdress, input.DateOfBirthMin, input.DateOfBirthMax, input.DateOfBaptismMin, input.DateOfBaptismMax, input.PlaceOfBaptism, input.DateOfConfirmationMin, input.DateOfConfirmationMax, input.PlaceOfConfirmation, input.Email, input.PhoneNumber, input.Father_FullName, input.Father_HolyName, input.Mother_FullName, input.Mother_HolyName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<MonkDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Monk>, List<MonkDto>>(items)
            };
        }

        public virtual async Task<MonkDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Monk, MonkDto>(await _monkRepository.GetAsync(id));
        }

        [Authorize(MonkBlogPermissions.Monks.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _monkRepository.DeleteAsync(id);
        }

        [Authorize(MonkBlogPermissions.Monks.Create)]
        public virtual async Task<MonkDto> CreateAsync(MonkCreateDto input)
        {
            var monk = ObjectMapper.Map<MonkCreateDto, Monk>(input);

            monk = await _monkRepository.InsertAsync(monk, autoSave: true);
            return ObjectMapper.Map<Monk, MonkDto>(monk);
        }

        [Authorize(MonkBlogPermissions.Monks.Edit)]
        public virtual async Task<MonkDto> UpdateAsync(Guid id, MonkUpdateDto input)
        {
            var monk = await _monkRepository.GetAsync(id);
            ObjectMapper.Map(input, monk);
            monk = await _monkRepository.UpdateAsync(monk);
            return ObjectMapper.Map<Monk, MonkDto>(monk);
        }
    }
}