using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTH.MonkBlog.Migrations
{
    public partial class Added_ReligousLife : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppReligousLives",
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
                    MonkId = table.Column<Guid>(nullable: false),
                    DateOfPractitioners = table.Column<DateTime>(nullable: false),
                    DateOfThinhVien = table.Column<DateTime>(nullable: false),
                    DateOfTapVien = table.Column<string>(nullable: true),
                    FirstKhan = table.Column<string>(nullable: true),
                    SecondKhan = table.Column<DateTime>(nullable: false),
                    ThirdKhan = table.Column<DateTime>(nullable: false),
                    RemainKhan = table.Column<DateTime>(nullable: false),
                    LifeTimeKhan = table.Column<DateTime>(nullable: false),
                    DateOfDeacon = table.Column<DateTime>(nullable: false),
                    DateOfPriest = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppReligousLives", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppReligousLives");
        }
    }
}
