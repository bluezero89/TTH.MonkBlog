using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using TTH.MonkBlog.EntityFrameworkCore;

namespace TTH.MonkBlog.Monks
{
    public class EfCoreMonkRepository : EfCoreRepository<MonkBlogDbContext, Monk, Guid>, IMonkRepository
    {
        public EfCoreMonkRepository(IDbContextProvider<MonkBlogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Monk>> GetListAsync(
            string filterText = null,
            string imgPath = null,
            string fullName = null,
            string holyName = null,
            string homeTown = null,
            string permanentAdress = null,
            DateTime? dateOfBirthMin = null,
            DateTime? dateOfBirthMax = null,
            DateTime? dateOfBaptismMin = null,
            DateTime? dateOfBaptismMax = null,
            string placeOfBaptism = null,
            DateTime? dateOfConfirmationMin = null,
            DateTime? dateOfConfirmationMax = null,
            string placeOfConfirmation = null,
            string email = null,
            string phoneNumber = null,
            string father_FullName = null,
            string father_HolyName = null,
            string mother_FullName = null,
            string mother_HolyName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, imgPath, fullName, holyName, homeTown, permanentAdress, dateOfBirthMin, dateOfBirthMax, dateOfBaptismMin, dateOfBaptismMax, placeOfBaptism, dateOfConfirmationMin, dateOfConfirmationMax, placeOfConfirmation, email, phoneNumber, father_FullName, father_HolyName, mother_FullName, mother_HolyName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MonkConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string imgPath = null,
            string fullName = null,
            string holyName = null,
            string homeTown = null,
            string permanentAdress = null,
            DateTime? dateOfBirthMin = null,
            DateTime? dateOfBirthMax = null,
            DateTime? dateOfBaptismMin = null,
            DateTime? dateOfBaptismMax = null,
            string placeOfBaptism = null,
            DateTime? dateOfConfirmationMin = null,
            DateTime? dateOfConfirmationMax = null,
            string placeOfConfirmation = null,
            string email = null,
            string phoneNumber = null,
            string father_FullName = null,
            string father_HolyName = null,
            string mother_FullName = null,
            string mother_HolyName = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, imgPath, fullName, holyName, homeTown, permanentAdress, dateOfBirthMin, dateOfBirthMax, dateOfBaptismMin, dateOfBaptismMax, placeOfBaptism, dateOfConfirmationMin, dateOfConfirmationMax, placeOfConfirmation, email, phoneNumber, father_FullName, father_HolyName, mother_FullName, mother_HolyName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Monk> ApplyFilter(
            IQueryable<Monk> query,
            string filterText,
            string imgPath = null,
            string fullName = null,
            string holyName = null,
            string homeTown = null,
            string permanentAdress = null,
            DateTime? dateOfBirthMin = null,
            DateTime? dateOfBirthMax = null,
            DateTime? dateOfBaptismMin = null,
            DateTime? dateOfBaptismMax = null,
            string placeOfBaptism = null,
            DateTime? dateOfConfirmationMin = null,
            DateTime? dateOfConfirmationMax = null,
            string placeOfConfirmation = null,
            string email = null,
            string phoneNumber = null,
            string father_FullName = null,
            string father_HolyName = null,
            string mother_FullName = null,
            string mother_HolyName = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ImgPath.Contains(filterText) || e.FullName.Contains(filterText) || e.HolyName.Contains(filterText) || e.HomeTown.Contains(filterText) || e.PermanentAdress.Contains(filterText) || e.PlaceOfBaptism.Contains(filterText) || e.PlaceOfConfirmation.Contains(filterText) || e.Email.Contains(filterText) || e.PhoneNumber.Contains(filterText) || e.Father_FullName.Contains(filterText) || e.Father_HolyName.Contains(filterText) || e.Mother_FullName.Contains(filterText) || e.Mother_HolyName.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(imgPath), e => e.ImgPath.Contains(imgPath))
                    .WhereIf(!string.IsNullOrWhiteSpace(fullName), e => e.FullName.Contains(fullName))
                    .WhereIf(!string.IsNullOrWhiteSpace(holyName), e => e.HolyName.Contains(holyName))
                    .WhereIf(!string.IsNullOrWhiteSpace(homeTown), e => e.HomeTown.Contains(homeTown))
                    .WhereIf(!string.IsNullOrWhiteSpace(permanentAdress), e => e.PermanentAdress.Contains(permanentAdress))
                    .WhereIf(dateOfBirthMin.HasValue, e => e.DateOfBirth >= dateOfBirthMin.Value)
                    .WhereIf(dateOfBirthMax.HasValue, e => e.DateOfBirth <= dateOfBirthMax.Value)
                    .WhereIf(dateOfBaptismMin.HasValue, e => e.DateOfBaptism >= dateOfBaptismMin.Value)
                    .WhereIf(dateOfBaptismMax.HasValue, e => e.DateOfBaptism <= dateOfBaptismMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(placeOfBaptism), e => e.PlaceOfBaptism.Contains(placeOfBaptism))
                    .WhereIf(dateOfConfirmationMin.HasValue, e => e.DateOfConfirmation >= dateOfConfirmationMin.Value)
                    .WhereIf(dateOfConfirmationMax.HasValue, e => e.DateOfConfirmation <= dateOfConfirmationMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(placeOfConfirmation), e => e.PlaceOfConfirmation.Contains(placeOfConfirmation))
                    .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email.Contains(email))
                    .WhereIf(!string.IsNullOrWhiteSpace(phoneNumber), e => e.PhoneNumber.Contains(phoneNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(father_FullName), e => e.Father_FullName.Contains(father_FullName))
                    .WhereIf(!string.IsNullOrWhiteSpace(father_HolyName), e => e.Father_HolyName.Contains(father_HolyName))
                    .WhereIf(!string.IsNullOrWhiteSpace(mother_FullName), e => e.Mother_FullName.Contains(mother_FullName))
                    .WhereIf(!string.IsNullOrWhiteSpace(mother_HolyName), e => e.Mother_HolyName.Contains(mother_HolyName));
        }
    }
}