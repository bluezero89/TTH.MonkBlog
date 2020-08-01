namespace TTH.MonkBlog.Monks
{
    public static class MonkConsts
    {
        private const string DefaultSorting = "{0}ImgPath asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Monk." : string.Empty);
        }

    }
}