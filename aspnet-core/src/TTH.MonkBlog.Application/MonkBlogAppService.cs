using TTH.MonkBlog.Localization;
using Volo.Abp.Application.Services;

namespace TTH.MonkBlog
{
    /* Inherit your application services from this class.
     */
    public abstract class MonkBlogAppService : ApplicationService
    {
        protected MonkBlogAppService()
        {
            LocalizationResource = typeof(MonkBlogResource);
        }
    }
}
