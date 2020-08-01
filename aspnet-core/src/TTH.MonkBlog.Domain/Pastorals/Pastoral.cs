using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace TTH.MonkBlog.Pastorals
{
    public class Pastoral : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid MonkId { get; set; }

        public virtual DateTime FromDate { get; set; }

        public virtual DateTime ToDate { get; set; }

        [CanBeNull]
        public virtual string PlaceOfPastoral { get; set; }

        public Pastoral()
        {

        }

        public Pastoral(Guid id, Guid monkId, DateTime fromDate, DateTime toDate, string placeOfPastoral)
        {
            Id = id;
            MonkId = monkId;
            FromDate = fromDate;
            ToDate = toDate;
            PlaceOfPastoral = placeOfPastoral;
        }
    }
}