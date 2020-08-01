using Microsoft.EntityFrameworkCore;
using TTH.MonkBlog.Users;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace TTH.MonkBlog.EntityFrameworkCore.Samples
{
    /* This is just an example test class.
     * Normally, you don't test ABP framework code
     * (like default AppUser repository IRepository<AppUser, Guid> here).
     * Only test your custom repository methods.
     */
    [Collection(MonkBlogTestConsts.CollectionDefinitionName)]
    public class SampleRepositoryTests : MonkBlogEntityFrameworkCoreTestBase
    {
        private readonly IRepository<AppUser, Guid> _appUserRepository;

        public SampleRepositoryTests()
        {
            _appUserRepository = GetRequiredService<IRepository<AppUser, Guid>>();
        }

        [Fact]
        public async Task Should_Query_AppUser()
        {
            /* Need to manually start Unit Of Work because
             * FirstOrDefaultAsync should be executed while db connection / context is available.
             */
            await WithUnitOfWorkAsync(async () =>
            {
                //Act
                var adminUser = await _appUserRepository
                    .Where(u => u.UserName == "admin")
                    .FirstOrDefaultAsync();

                //Assert
                adminUser.ShouldNotBeNull();
            });
        }
    }
}
