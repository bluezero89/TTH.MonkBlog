using TTH.MonkBlog.Pastorals;
using TTH.MonkBlog.StudyHistories;
using TTH.MonkBlog.ReligousLives;
using Volo.Abp.EntityFrameworkCore.Modeling;
using TTH.MonkBlog.Monks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace TTH.MonkBlog.EntityFrameworkCore
{
    public static class MonkBlogDbContextModelCreatingExtensions
    {
        public static void ConfigureMonkBlog(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(MonkBlogConsts.DbTablePrefix + "YourEntities", MonkBlogConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.Entity<Monk>(b =>
            {
                b.ToTable(MonkBlogConsts.DbTablePrefix + "Monks", MonkBlogConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.ImgPath).HasColumnName(nameof(Monk.ImgPath));
                b.Property(x => x.FullName).HasColumnName(nameof(Monk.FullName));
                b.Property(x => x.HolyName).HasColumnName(nameof(Monk.HolyName));
                b.Property(x => x.HomeTown).HasColumnName(nameof(Monk.HomeTown));
                b.Property(x => x.PermanentAdress).HasColumnName(nameof(Monk.PermanentAdress));
                b.Property(x => x.DateOfBirth).HasColumnName(nameof(Monk.DateOfBirth));
                b.Property(x => x.DateOfBaptism).HasColumnName(nameof(Monk.DateOfBaptism));
                b.Property(x => x.PlaceOfBaptism).HasColumnName(nameof(Monk.PlaceOfBaptism));
                b.Property(x => x.DateOfConfirmation).HasColumnName(nameof(Monk.DateOfConfirmation));
                b.Property(x => x.PlaceOfConfirmation).HasColumnName(nameof(Monk.PlaceOfConfirmation));
                b.Property(x => x.Email).HasColumnName(nameof(Monk.Email));
                b.Property(x => x.PhoneNumber).HasColumnName(nameof(Monk.PhoneNumber));
                b.Property(x => x.Father_FullName).HasColumnName(nameof(Monk.Father_FullName));
                b.Property(x => x.Father_HolyName).HasColumnName(nameof(Monk.Father_HolyName));
                b.Property(x => x.Mother_FullName).HasColumnName(nameof(Monk.Mother_FullName));
                b.Property(x => x.Mother_HolyName).HasColumnName(nameof(Monk.Mother_HolyName));
            });

            builder.Entity<ReligousLife>(b =>
            {
                b.ToTable(MonkBlogConsts.DbTablePrefix + "ReligousLives", MonkBlogConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.MonkId).HasColumnName(nameof(ReligousLife.MonkId));
                b.Property(x => x.DateOfPractitioners).HasColumnName(nameof(ReligousLife.DateOfPractitioners));
                b.Property(x => x.DateOfThinhVien).HasColumnName(nameof(ReligousLife.DateOfThinhVien));
                b.Property(x => x.DateOfTapVien).HasColumnName(nameof(ReligousLife.DateOfTapVien));
                b.Property(x => x.FirstKhan).HasColumnName(nameof(ReligousLife.FirstKhan));
                b.Property(x => x.SecondKhan).HasColumnName(nameof(ReligousLife.SecondKhan));
                b.Property(x => x.ThirdKhan).HasColumnName(nameof(ReligousLife.ThirdKhan));
                b.Property(x => x.RemainKhan).HasColumnName(nameof(ReligousLife.RemainKhan));
                b.Property(x => x.LifeTimeKhan).HasColumnName(nameof(ReligousLife.LifeTimeKhan));
                b.Property(x => x.DateOfDeacon).HasColumnName(nameof(ReligousLife.DateOfDeacon));
                b.Property(x => x.DateOfPriest).HasColumnName(nameof(ReligousLife.DateOfPriest));
            });

            builder.Entity<StudyHistory>(b =>
            {
                b.ToTable(MonkBlogConsts.DbTablePrefix + "StudyHistories", MonkBlogConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Diploma).HasColumnName(nameof(StudyHistory.Diploma));
                b.Property(x => x.AcademicLevel).HasColumnName(nameof(StudyHistory.AcademicLevel));
                b.Property(x => x.StudyAt).HasColumnName(nameof(StudyHistory.StudyAt));
                b.Property(x => x.FromDate).HasColumnName(nameof(StudyHistory.FromDate));
                b.Property(x => x.ToDate).HasColumnName(nameof(StudyHistory.ToDate));
                b.Property(x => x.Achievements).HasColumnName(nameof(StudyHistory.Achievements));
            });

            builder.Entity<Pastoral>(b =>
            {
                b.ToTable(MonkBlogConsts.DbTablePrefix + "Pastorals", MonkBlogConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.MonkId).HasColumnName(nameof(Pastoral.MonkId));
                b.Property(x => x.FromDate).HasColumnName(nameof(Pastoral.FromDate));
                b.Property(x => x.ToDate).HasColumnName(nameof(Pastoral.ToDate));
                b.Property(x => x.PlaceOfPastoral).HasColumnName(nameof(Pastoral.PlaceOfPastoral));
            });
        }
    }
}