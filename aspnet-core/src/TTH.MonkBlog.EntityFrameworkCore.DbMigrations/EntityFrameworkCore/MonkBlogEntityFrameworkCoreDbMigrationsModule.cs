using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace TTH.MonkBlog.EntityFrameworkCore
{
    [DependsOn(
        typeof(MonkBlogEntityFrameworkCoreModule)
    )]
    public class MonkBlogEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MonkBlogMigrationsDbContext>();
        }
    }
}