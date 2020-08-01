using Volo.Abp.Application.Dtos;
using System;

namespace TTH.MonkBlog.ReligousLives
{
    public class GetReligousLivesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public Guid? MonkId { get; set; }
        public DateTime? DateOfPractitionersMin { get; set; }
        public DateTime? DateOfPractitionersMax { get; set; }
        public DateTime? DateOfThinhVienMin { get; set; }
        public DateTime? DateOfThinhVienMax { get; set; }
        public string DateOfTapVien { get; set; }
        public string FirstKhan { get; set; }
        public DateTime? SecondKhanMin { get; set; }
        public DateTime? SecondKhanMax { get; set; }
        public DateTime? ThirdKhanMin { get; set; }
        public DateTime? ThirdKhanMax { get; set; }
        public DateTime? RemainKhanMin { get; set; }
        public DateTime? RemainKhanMax { get; set; }
        public DateTime? LifeTimeKhanMin { get; set; }
        public DateTime? LifeTimeKhanMax { get; set; }
        public DateTime? DateOfDeaconMin { get; set; }
        public DateTime? DateOfDeaconMax { get; set; }
        public DateTime? DateOfPriestMin { get; set; }
        public DateTime? DateOfPriestMax { get; set; }

        public GetReligousLivesInput()
        {

        }
    }
}