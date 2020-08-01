using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TTH.MonkBlog.Pastorals
{
    public interface IPastoralRepository : IRepository<Pastoral, Guid>
    {
        Task<List<Pastoral>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            Guid? monkId = null,
            DateTime? fromDateMin = null,
            DateTime? fromDateMax = null,
            DateTime? toDateMin = null,
            DateTime? toDateMax = null,
            string placeOfPastoral = null,
            CancellationToken cancellationToken = default);
    }
}