using TTH.MonkBlog.EntityFrameworkCore;
using Xunit;

namespace TTH.MonkBlog
{
    [CollectionDefinition(MonkBlogTestConsts.CollectionDefinitionName)]
    public class MonkBlogApplicationCollection : MonkBlogEntityFrameworkCoreCollectionFixtureBase
    {

    }
}
