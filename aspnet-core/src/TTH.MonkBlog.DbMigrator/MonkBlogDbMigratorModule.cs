using TTH.MonkBlog.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace TTH.MonkBlog.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(MonkBlogEntityFrameworkCoreDbMigrationsModule),
        typeof(MonkBlogApplicationContractsModule)
    )]
    public class MonkBlogDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}