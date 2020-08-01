using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TTH.MonkBlog.StudyHistories
{
    public interface IStudyHistoryRepository : IRepository<StudyHistory, Guid>
    {
        Task<List<StudyHistory>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string diploma = null,
            string academicLevel = null,
            string studyAt = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            string achievements = null,
            CancellationToken cancellationToken = default);
    }
}