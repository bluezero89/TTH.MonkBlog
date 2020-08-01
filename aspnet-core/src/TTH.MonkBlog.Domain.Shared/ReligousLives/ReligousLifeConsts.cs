namespace TTH.MonkBlog.ReligousLives
{
    public static class ReligousLifeConsts
    {
        private const string DefaultSorting = "{0}MonkId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ReligousLife." : string.Empty);
        }

    }
}