using Volo.Abp.Application.Dtos;
using System;

namespace TTH.MonkBlog.Monks
{
    public class GetMonksInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string ImgPath { get; set; }
        public string FullName { get; set; }
        public string HolyName { get; set; }
        public string HomeTown { get; set; }
        public string PermanentAdress { get; set; }
        public DateTime? DateOfBirthMin { get; set; }
        public DateTime? DateOfBirthMax { get; set; }
        public DateTime? DateOfBaptismMin { get; set; }
        public DateTime? DateOfBaptismMax { get; set; }
        public string PlaceOfBaptism { get; set; }
        public DateTime? DateOfConfirmationMin { get; set; }
        public DateTime? DateOfConfirmationMax { get; set; }
        public string PlaceOfConfirmation { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Father_FullName { get; set; }
        public string Father_HolyName { get; set; }
        public string Mother_FullName { get; set; }
        public string Mother_HolyName { get; set; }

        public GetMonksInput()
        {

        }
    }
}