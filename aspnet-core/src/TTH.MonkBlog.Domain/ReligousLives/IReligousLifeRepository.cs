using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TTH.MonkBlog.ReligousLives
{
    public interface IReligousLifeRepository : IRepository<ReligousLife, Guid>
    {
        Task<List<ReligousLife>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}