using Volo.Abp.Application.Dtos;
using System;

namespace TTH.MonkBlog.StudyHistories
{
    public class GetStudyHistoriesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Diploma { get; set; }
        public string AcademicLevel { get; set; }
        public string StudyAt { get; set; }
        public DateTime? FromDateMin { get; set; }
        public DateTime? FromDateMax { get; set; }
        public DateTime? ToDateMin { get; set; }
        public DateTime? ToDateMax { get; set; }
        public string Achievements { get; set; }

        public GetStudyHistoriesInput()
        {

        }
    }
}