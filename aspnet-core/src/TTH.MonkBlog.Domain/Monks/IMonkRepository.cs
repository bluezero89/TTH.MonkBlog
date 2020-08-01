using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TTH.MonkBlog.Monks
{
    public interface IMonkRepository : IRepository<Monk, Guid>
    {
        Task<List<Monk>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}