using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace TTH.MonkBlog.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(MonkBlogHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MonkBlogConsoleApiClientModule : AbpModule
    {
        
    }
}
