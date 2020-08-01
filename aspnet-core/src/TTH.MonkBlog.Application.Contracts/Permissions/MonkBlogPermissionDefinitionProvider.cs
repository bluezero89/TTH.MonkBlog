using TTH.MonkBlog.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace TTH.MonkBlog.Permissions
{
    public class MonkBlogPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MonkBlogPermissions.GroupName);

            myGroup.AddPermission(MonkBlogPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(MonkBlogPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(MonkBlogPermissions.MyPermission1, L("Permission:MyPermission1"));

            var monkPermission = myGroup.AddPermission(MonkBlogPermissions.Monks.Default, L("Permission:Monks"));
            monkPermission.AddChild(MonkBlogPermissions.Monks.Create, L("Permission:Create"));
            monkPermission.AddChild(MonkBlogPermissions.Monks.Edit, L("Permission:Edit"));
            monkPermission.AddChild(MonkBlogPermissions.Monks.Delete, L("Permission:Delete"));

            var religousLifePermission = myGroup.AddPermission(MonkBlogPermissions.ReligousLives.Default, L("Permission:ReligousLives"));
            religousLifePermission.AddChild(MonkBlogPermissions.ReligousLives.Create, L("Permission:Create"));
            religousLifePermission.AddChild(MonkBlogPermissions.ReligousLives.Edit, L("Permission:Edit"));
            religousLifePermission.AddChild(MonkBlogPermissions.ReligousLives.Delete, L("Permission:Delete"));

            var studyHistoryPermission = myGroup.AddPermission(MonkBlogPermissions.StudyHistories.Default, L("Permission:StudyHistories"));
            studyHistoryPermission.AddChild(MonkBlogPermissions.StudyHistories.Create, L("Permission:Create"));
            studyHistoryPermission.AddChild(MonkBlogPermissions.StudyHistories.Edit, L("Permission:Edit"));
            studyHistoryPermission.AddChild(MonkBlogPermissions.StudyHistories.Delete, L("Permission:Delete"));

            var pastoralPermission = myGroup.AddPermission(MonkBlogPermissions.Pastorals.Default, L("Permission:Pastorals"));
            pastoralPermission.AddChild(MonkBlogPermissions.Pastorals.Create, L("Permission:Create"));
            pastoralPermission.AddChild(MonkBlogPermissions.Pastorals.Edit, L("Permission:Edit"));
            pastoralPermission.AddChild(MonkBlogPermissions.Pastorals.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MonkBlogResource>(name);
        }
    }
}