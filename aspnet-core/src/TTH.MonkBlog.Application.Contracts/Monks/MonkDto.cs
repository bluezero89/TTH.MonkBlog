using System;
using Volo.Abp.Application.Dtos;

namespace TTH.MonkBlog.Monks
{
    public class MonkDto : FullAuditedEntityDto<Guid>
    {
        public string ImgPath { get; set; }
        public string FullName { get; set; }
        public string HolyName { get; set; }
        public string HomeTown { get; set; }
        public string PermanentAdress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfBaptism { get; set; }
        public string PlaceOfBaptism { get; set; }
        public DateTime? DateOfConfirmation { get; set; }
        public string PlaceOfConfirmation { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Father_FullName { get; set; }
        public string Father_HolyName { get; set; }
        public string Mother_FullName { get; set; }
        public string Mother_HolyName { get; set; }
    }
}