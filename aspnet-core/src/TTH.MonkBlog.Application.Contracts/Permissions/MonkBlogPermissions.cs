namespace TTH.MonkBlog.Permissions
{
    public static class MonkBlogPermissions
    {
        public const string GroupName = "MonkBlog";

        public static class Dashboard
        {
            public const string DashboardGroup = GroupName + ".Dashboard";
            public const string Host = DashboardGroup + ".Host";
            public const string Tenant = GroupName + ".Tenant";
        }

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Monks
        {
            public const string Default = GroupName + ".Monks";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class ReligousLives
        {
            public const string Default = GroupName + ".ReligousLives";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class StudyHistories
        {
            public const string Default = GroupName + ".StudyHistories";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Pastorals
        {
            public const string Default = GroupName + ".Pastorals";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}