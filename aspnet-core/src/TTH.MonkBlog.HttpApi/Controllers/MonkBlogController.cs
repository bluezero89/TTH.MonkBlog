using TTH.MonkBlog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TTH.MonkBlog.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class MonkBlogController : AbpController
    {
        protected MonkBlogController()
        {
            LocalizationResource = typeof(MonkBlogResource);
        }
    }
}