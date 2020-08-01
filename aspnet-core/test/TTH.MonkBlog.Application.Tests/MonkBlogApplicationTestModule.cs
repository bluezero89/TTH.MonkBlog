using Volo.Abp.Modularity;

namespace TTH.MonkBlog
{
    [DependsOn(
        typeof(MonkBlogApplicationModule),
        typeof(MonkBlogDomainTestModule)
        )]
    public class MonkBlogApplicationTestModule : AbpModule
    {

    }
}