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

namespace TTH.MonkBlog.StudyHistories
{
    public class EfCoreStudyHistoryRepository : EfCoreRepository<MonkBlogDbContext, StudyHistory, Guid>, IStudyHistoryRepository
    {
        public EfCoreStudyHistoryRepository(IDbContextProvider<MonkBlogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<StudyHistory>> GetListAsync(
            string filterText = null,
            string diploma = null,
            string academicLevel = null,
            string studyAt = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            string achievements = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, diploma, academicLevel, studyAt, fromDateMin, fromDateMax, toDateMin, toDateMax, achievements);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? StudyHistoryConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string diploma = null,
            string academicLevel = null,
            string studyAt = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            string achievements = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, diploma, academicLevel, studyAt, fromDateMin, fromDateMax, toDateMin, toDateMax, achievements);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<StudyHistory> ApplyFilter(
            IQueryable<StudyHistory> query,
            string filterText,
            string diploma = null,
            string academicLevel = null,
            string studyAt = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            string achievements = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Diploma.Contains(filterText) || e.AcademicLevel.Contains(filterText) || e.StudyAt.Contains(filterText) || e.Achievements.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(diploma), e => e.Diploma.Contains(diploma))
                    .WhereIf(!string.IsNullOrWhiteSpace(academicLevel), e => e.AcademicLevel.Contains(academicLevel))
                    .WhereIf(!string.IsNullOrWhiteSpace(studyAt), e => e.StudyAt.Contains(studyAt))
                    .WhereIf(fromDateMin.HasValue, e => e.FromDate >= fromDateMin.Value)
                    .WhereIf(fromDateMax.HasValue, e => e.FromDate <= fromDateMax.Value)
                    .WhereIf(toDateMin.HasValue, e => e.ToDate >= toDateMin.Value)
                    .WhereIf(toDateMax.HasValue, e => e.ToDate <= toDateMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(achievements), e => e.Achievements.Contains(achievements));
        }
    }
}