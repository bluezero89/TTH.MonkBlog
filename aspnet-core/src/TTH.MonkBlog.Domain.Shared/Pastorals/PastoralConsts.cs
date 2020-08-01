namespace TTH.MonkBlog.Pastorals
{
    public static class PastoralConsts
    {
        private const string DefaultSorting = "{0}MonkId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Pastoral." : string.Empty);
        }

    }
}