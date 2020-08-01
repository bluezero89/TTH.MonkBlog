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

namespace TTH.MonkBlog.ReligousLives
{
    public class EfCoreReligousLifeRepository : EfCoreRepository<MonkBlogDbContext, ReligousLife, Guid>, IReligousLifeRepository
    {
        public EfCoreReligousLifeRepository(IDbContextProvider<MonkBlogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ReligousLife>> GetListAsync(
            string filterText = null,
            Guid? monkId = null,
            DateTime? dateOfPractitionersMin = null,
            DateTime? dateOfPractitionersMax = null,
            DateTime? dateOfThinhVienMin = null,
            DateTime? dateOfThinhVienMax = null,
            string dateOfTapVien = null,
            string firstKhan = null,
            DateTime? secondKhanMin = null,
            DateTime? secondKhanMax = null,
            DateTime? thirdKhanMin = null,
            DateTime? thirdKhanMax = null,
            DateTime? remainKhanMin = null,
            DateTime? remainKhanMax = null,
            DateTime? lifeTimeKhanMin = null,
            DateTime? lifeTimeKhanMax = null,
            DateTime? dateOfDeaconMin = null,
            DateTime? dateOfDeaconMax = null,
            DateTime? dateOfPriestMin = null,
            DateTime? dateOfPriestMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, monkId, dateOfPractitionersMin, dateOfPractitionersMax, dateOfThinhVienMin, dateOfThinhVienMax, dateOfTapVien, firstKhan, secondKhanMin, secondKhanMax, thirdKhanMin, thirdKhanMax, remainKhanMin, remainKhanMax, lifeTimeKhanMin, lifeTimeKhanMax, dateOfDeaconMin, dateOfDeaconMax, dateOfPriestMin, dateOfPriestMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ReligousLifeConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? monkId = null,
            DateTime? dateOfPractitionersMin = null,
            DateTime? dateOfPractitionersMax = null,
            DateTime? dateOfThinhVienMin = null,
            DateTime? dateOfThinhVienMax = null,
            string dateOfTapVien = null,
            string firstKhan = null,
            DateTime? secondKhanMin = null,
            DateTime? secondKhanMax = null,
            DateTime? thirdKhanMin = null,
            DateTime? thirdKhanMax = null,
            DateTime? remainKhanMin = null,
            DateTime? remainKhanMax = null,
            DateTime? lifeTimeKhanMin = null,
            DateTime? lifeTimeKhanMax = null,
            DateTime? dateOfDeaconMin = null,
            DateTime? dateOfDeaconMax = null,
            DateTime? dateOfPriestMin = null,
            DateTime? dateOfPriestMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, monkId, dateOfPractitionersMin, dateOfPractitionersMax, dateOfThinhVienMin, dateOfThinhVienMax, dateOfTapVien, firstKhan, secondKhanMin, secondKhanMax, thirdKhanMin, thirdKhanMax, remainKhanMin, remainKhanMax, lifeTimeKhanMin, lifeTimeKhanMax, dateOfDeaconMin, dateOfDeaconMax, dateOfPriestMin, dateOfPriestMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ReligousLife> ApplyFilter(
            IQueryable<ReligousLife> query,
            string filterText,
            Guid? monkId = null,
            DateTime? dateOfPractitionersMin = null,
            DateTime? dateOfPractitionersMax = null,
            DateTime? dateOfThinhVienMin = null,
            DateTime? dateOfThinhVienMax = null,
            string dateOfTapVien = null,
            string firstKhan = null,
            DateTime? secondKhanMin = null,
            DateTime? secondKhanMax = null,
            DateTime? thirdKhanMin = null,
            DateTime? thirdKhanMax = null,
            DateTime? remainKhanMin = null,
            DateTime? remainKhanMax = null,
            DateTime? lifeTimeKhanMin = null,
            DateTime? lifeTimeKhanMax = null,
            DateTime? dateOfDeaconMin = null,
            DateTime? dateOfDeaconMax = null,
            DateTime? dateOfPriestMin = null,
            DateTime? dateOfPriestMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.DateOfTapVien.Contains(filterText) || e.FirstKhan.Contains(filterText))
                    .WhereIf(monkId.HasValue, e => e.MonkId == monkId)
                    .WhereIf(dateOfPractitionersMin.HasValue, e => e.DateOfPractitioners >= dateOfPractitionersMin.Value)
                    .WhereIf(dateOfPractitionersMax.HasValue, e => e.DateOfPractitioners <= dateOfPractitionersMax.Value)
                    .WhereIf(dateOfThinhVienMin.HasValue, e => e.DateOfThinhVien >= dateOfThinhVienMin.Value)
                    .WhereIf(dateOfThinhVienMax.HasValue, e => e.DateOfThinhVien <= dateOfThinhVienMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(dateOfTapVien), e => e.DateOfTapVien.Contains(dateOfTapVien))
                    .WhereIf(!string.IsNullOrWhiteSpace(firstKhan), e => e.FirstKhan.Contains(firstKhan))
                    .WhereIf(secondKhanMin.HasValue, e => e.SecondKhan >= secondKhanMin.Value)
                    .WhereIf(secondKhanMax.HasValue, e => e.SecondKhan <= secondKhanMax.Value)
                    .WhereIf(thirdKhanMin.HasValue, e => e.ThirdKhan >= thirdKhanMin.Value)
                    .WhereIf(thirdKhanMax.HasValue, e => e.ThirdKhan <= thirdKhanMax.Value)
                    .WhereIf(remainKhanMin.HasValue, e => e.RemainKhan >= remainKhanMin.Value)
                    .WhereIf(remainKhanMax.HasValue, e => e.RemainKhan <= remainKhanMax.Value)
                    .WhereIf(lifeTimeKhanMin.HasValue, e => e.LifeTimeKhan >= lifeTimeKhanMin.Value)
                    .WhereIf(lifeTimeKhanMax.HasValue, e => e.LifeTimeKhan <= lifeTimeKhanMax.Value)
                    .WhereIf(dateOfDeaconMin.HasValue, e => e.DateOfDeacon >= dateOfDeaconMin.Value)
                    .WhereIf(dateOfDeaconMax.HasValue, e => e.DateOfDeacon <= dateOfDeaconMax.Value)
                    .WhereIf(dateOfPriestMin.HasValue, e => e.DateOfPriest >= dateOfPriestMin.Value)
                    .WhereIf(dateOfPriestMax.HasValue, e => e.DateOfPriest <= dateOfPriestMax.Value);
        }
    }
}