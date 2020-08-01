using System;
using System.ComponentModel.DataAnnotations;

namespace TTH.MonkBlog.Monks
{
    public class MonkUpdateDto
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