using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTH.MonkBlog.Migrations
{
    public partial class Added_Monk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppMonks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ImgPath = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    HolyName = table.Column<string>(nullable: true),
                    HomeTown = table.Column<string>(nullable: true),
                    PermanentAdress = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateOfBaptism = table.Column<DateTime>(nullable: false),
                    PlaceOfBaptism = table.Column<string>(nullable: true),
                    DateOfConfirmation = table.Column<DateTime>(nullable: false),
                    PlaceOfConfirmation = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Father_FullName = table.Column<string>(nullable: true),
                    Father_HolyName = table.Column<string>(nullable: true),
                    Mother_FullName = table.Column<string>(nullable: true),
                    Mother_HolyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMonks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppMonks");
        }
    }
}
