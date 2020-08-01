using Volo.Abp.Settings;

namespace TTH.MonkBlog.Settings
{
    public class MonkBlogSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(MonkBlogSettings.MySetting1));
        }
    }
}
