using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace TTH.MonkBlog.ReligousLives
{
    public class ReligousLife : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid MonkId { get; set; }

        public virtual DateTime DateOfPractitioners { get; set; }

        public virtual DateTime DateOfThinhVien { get; set; }

        [CanBeNull]
        public virtual string DateOfTapVien { get; set; }

        [CanBeNull]
        public virtual string FirstKhan { get; set; }

        public virtual DateTime SecondKhan { get; set; }

        public virtual DateTime ThirdKhan { get; set; }

        public virtual DateTime RemainKhan { get; set; }

        public virtual DateTime LifeTimeKhan { get; set; }

        public virtual DateTime DateOfDeacon { get; set; }

        public virtual DateTime DateOfPriest { get; set; }

        public ReligousLife()
        {

        }

        public ReligousLife(Guid id, Guid monkId, DateTime dateOfPractitioners, DateTime dateOfThinhVien, string dateOfTapVien, string firstKhan, DateTime secondKhan, DateTime thirdKhan, DateTime remainKhan, DateTime lifeTimeKhan, DateTime dateOfDeacon, DateTime dateOfPriest)
        {
            Id = id;
            MonkId = monkId;
            DateOfPractitioners = dateOfPractitioners;
            DateOfThinhVien = dateOfThinhVien;
            DateOfTapVien = dateOfTapVien;
            FirstKhan = firstKhan;
            SecondKhan = secondKhan;
            ThirdKhan = thirdKhan;
            RemainKhan = remainKhan;
            LifeTimeKhan = lifeTimeKhan;
            DateOfDeacon = dateOfDeacon;
            DateOfPriest = dateOfPriest;
        }
    }
}