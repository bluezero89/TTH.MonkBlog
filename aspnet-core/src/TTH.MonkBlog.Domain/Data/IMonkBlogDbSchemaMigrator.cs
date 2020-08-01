using System.Threading.Tasks;

namespace TTH.MonkBlog.Data
{
    public interface IMonkBlogDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}