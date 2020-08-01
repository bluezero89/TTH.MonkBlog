using System;
using System.ComponentModel.DataAnnotations;

namespace TTH.MonkBlog.ReligousLives
{
    public class ReligousLifeUpdateDto
    {
        public Guid MonkId { get; set; }
        public DateTime DateOfPractitioners { get; set; }
        public DateTime DateOfThinhVien { get; set; }
        public string DateOfTapVien { get; set; }
        public string FirstKhan { get; set; }
        public DateTime SecondKhan { get; set; }
        public DateTime ThirdKhan { get; set; }
        public DateTime RemainKhan { get; set; }
        public DateTime LifeTimeKhan { get; set; }
        public DateTime DateOfDeacon { get; set; }
        public DateTime DateOfPriest { get; set; }
    }
}