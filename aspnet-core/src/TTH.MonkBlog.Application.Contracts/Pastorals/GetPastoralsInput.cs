using Volo.Abp.Application.Dtos;
using System;

namespace TTH.MonkBlog.Pastorals
{
    public class GetPastoralsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public Guid? MonkId { get; set; }
        public DateTime? FromDateMin { get; set; }
        public DateTime? FromDateMax { get; set; }
        public DateTime? ToDateMin { get; set; }
        public DateTime? ToDateMax { get; set; }
        public string PlaceOfPastoral { get; set; }

        public GetPastoralsInput()
        {

        }
    }
}