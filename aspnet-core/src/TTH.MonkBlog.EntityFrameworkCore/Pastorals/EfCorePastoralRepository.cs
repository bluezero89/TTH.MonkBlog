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

namespace TTH.MonkBlog.Pastorals
{
    public class EfCorePastoralRepository : EfCoreRepository<MonkBlogDbContext, Pastoral, Guid>, IPastoralRepository
    {
        public EfCorePastoralRepository(IDbContextProvider<MonkBlogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Pastoral>> GetListAsync(
            string filterText = null,
            Guid? monkId = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            string placeOfPastoral = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, monkId, fromDateMin, fromDateMax, toDateMin, toDateMax, placeOfPastoral);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PastoralConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? monkId = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            string placeOfPastoral = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, monkId, fromDateMin, fromDateMax, toDateMin, toDateMax, placeOfPastoral);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Pastoral> ApplyFilter(
            IQueryable<Pastoral> query,
            string filterText,
            Guid? monkId = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            string placeOfPastoral = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.PlaceOfPastoral.Contains(filterText))
                    .WhereIf(monkId.HasValue, e => e.MonkId == monkId)
                    .WhereIf(fromDateMin.HasValue, e => e.FromDate >= fromDateMin.Value)
                    .WhereIf(fromDateMax.HasValue, e => e.FromDate <= fromDateMax.Value)
                    .WhereIf(toDateMin.HasValue, e => e.ToDate >= toDateMin.Value)
                    .WhereIf(toDateMax.HasValue, e => e.ToDate <= toDateMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(placeOfPastoral), e => e.PlaceOfPastoral.Contains(placeOfPastoral));
        }
    }
}