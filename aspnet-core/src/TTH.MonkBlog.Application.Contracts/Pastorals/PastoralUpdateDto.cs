using System;
using System.ComponentModel.DataAnnotations;

namespace TTH.MonkBlog.Pastorals
{
    public class PastoralUpdateDto
    {
        public Guid MonkId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string PlaceOfPastoral { get; set; }
    }
}