using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TTH.MonkBlog.Data
{
    /* This is used if database provider does't define
     * IMonkBlogDbSchemaMigrator implementation.
     */
    public class NullMonkBlogDbSchemaMigrator : IMonkBlogDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}