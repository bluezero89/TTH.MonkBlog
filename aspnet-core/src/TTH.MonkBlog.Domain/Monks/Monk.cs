using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace TTH.MonkBlog.Monks
{
    public class Monk : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string ImgPath { get; set; }

        [CanBeNull]
        public virtual string FullName { get; set; }

        [CanBeNull]
        public virtual string HolyName { get; set; }

        [CanBeNull]
        public virtual string HomeTown { get; set; }

        [CanBeNull]
        public virtual string PermanentAdress { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

        public virtual DateTime DateOfBaptism { get; set; }

        [CanBeNull]
        public virtual string PlaceOfBaptism { get; set; }

        public virtual DateTime DateOfConfirmation { get; set; }

        [CanBeNull]
        public virtual string PlaceOfConfirmation { get; set; }

        [CanBeNull]
        public virtual string Email { get; set; }

        [CanBeNull]
        public virtual string PhoneNumber { get; set; }

        [CanBeNull]
        public virtual string Father_FullName { get; set; }

        [CanBeNull]
        public virtual string Father_HolyName { get; set; }

        [CanBeNull]
        public virtual string Mother_FullName { get; set; }

        [CanBeNull]
        public virtual string Mother_HolyName { get; set; }

        public Monk()
        {

        }

        public Monk(Guid id, string imgPath, string fullName, string holyName, string homeTown, string permanentAdress, DateTime dateOfBirth, DateTime dateOfBaptism, string placeOfBaptism, DateTime dateOfConfirmation, string placeOfConfirmation, string email, string phoneNumber, string father_FullName, string father_HolyName, string mother_FullName, string mother_HolyName)
        {
            Id = id;
            ImgPath = imgPath;
            FullName = fullName;
            HolyName = holyName;
            HomeTown = homeTown;
            PermanentAdress = permanentAdress;
            DateOfBirth = dateOfBirth;
            DateOfBaptism = dateOfBaptism;
            PlaceOfBaptism = placeOfBaptism;
            DateOfConfirmation = dateOfConfirmation;
            PlaceOfConfirmation = placeOfConfirmation;
            Email = email;
            PhoneNumber = phoneNumber;
            Father_FullName = father_FullName;
            Father_HolyName = father_HolyName;
            Mother_FullName = mother_FullName;
            Mother_HolyName = mother_HolyName;
        }
    }
}