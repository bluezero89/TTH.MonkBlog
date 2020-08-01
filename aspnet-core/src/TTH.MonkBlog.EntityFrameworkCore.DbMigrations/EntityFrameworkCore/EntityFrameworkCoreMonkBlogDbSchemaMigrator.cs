using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TTH.MonkBlog.Data;
using Volo.Abp.DependencyInjection;

namespace TTH.MonkBlog.EntityFrameworkCore
{
    public class EntityFrameworkCoreMonkBlogDbSchemaMigrator
        : IMonkBlogDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreMonkBlogDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the MonkBlogMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<MonkBlogMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}