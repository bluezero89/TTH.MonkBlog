using System;
using Volo.Abp.Application.Dtos;

namespace TTH.MonkBlog.Pastorals
{
    public class PastoralDto : FullAuditedEntityDto<Guid>
    {
        public Guid MonkId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string PlaceOfPastoral { get; set; }
    }
}