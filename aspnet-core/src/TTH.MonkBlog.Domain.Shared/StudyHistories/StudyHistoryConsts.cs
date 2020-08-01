namespace TTH.MonkBlog.StudyHistories
{
    public static class StudyHistoryConsts
    {
        private const string DefaultSorting = "{0}Diploma asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "StudyHistory." : string.Empty);
        }

    }
}