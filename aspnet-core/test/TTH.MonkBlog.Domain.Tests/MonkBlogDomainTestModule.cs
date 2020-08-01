using TTH.MonkBlog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TTH.MonkBlog
{
    [DependsOn(
        typeof(MonkBlogEntityFrameworkCoreTestModule)
        )]
    public class MonkBlogDomainTestModule : AbpModule
    {

    }
}