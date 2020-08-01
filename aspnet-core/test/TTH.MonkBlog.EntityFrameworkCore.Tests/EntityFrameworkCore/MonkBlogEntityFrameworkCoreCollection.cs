using Xunit;

namespace TTH.MonkBlog.EntityFrameworkCore
{
    [CollectionDefinition(MonkBlogTestConsts.CollectionDefinitionName)]
    public class MonkBlogEntityFrameworkCoreCollection : ICollectionFixture<MonkBlogEntityFrameworkCoreFixture>
    {

    }
}
