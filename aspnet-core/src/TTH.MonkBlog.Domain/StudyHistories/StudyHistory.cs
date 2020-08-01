using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace TTH.MonkBlog.StudyHistories
{
    public class StudyHistory : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string Diploma { get; set; }

        [CanBeNull]
        public virtual string AcademicLevel { get; set; }

        [CanBeNull]
        public virtual string StudyAt { get; set; }

        public virtual DateTime FromDate { get; set; }

        public virtual DateTime ToDate { get; set; }

        [CanBeNull]
        public virtual string Achievements { get; set; }

        public StudyHistory()
        {

        }

        public StudyHistory(Guid id, string diploma, string academicLevel, string studyAt, DateTime fromDate, DateTime toDate, string achievements)
        {
            Id = id;
            Diploma = diploma;
            AcademicLevel = academicLevel;
            StudyAt = studyAt;
            FromDate = fromDate;
            ToDate = toDate;
            Achievements = achievements;
        }
    }
}