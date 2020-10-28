using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gvips.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Age = table.Column<int>(maxLength: 3, nullable: false),
                    PostEmail = table.Column<string>(maxLength: 255, nullable: true),
                    Ethnicity = table.Column<int>(nullable: false),
                    Eyes = table.Column<string>(maxLength: 10, nullable: true),
                    SocialNetworks = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Height = table.Column<string>(maxLength: 5, nullable: true),
                    Hips = table.Column<string>(maxLength: 5, nullable: true),
                    HairColor = table.Column<int>(nullable: false),
                    Incall = table.Column<int>(nullable: false),
                    Outcall = table.Column<int>(nullable: false),
                    Affiliation = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Country = table.Column<string>(maxLength: 30, nullable: true),
                    State = table.Column<string>(maxLength: 30, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    OnlineStatus = table.Column<int>(nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 140, nullable: true),
                    Description = table.Column<string>(maxLength: 5000, nullable: true),
                    Waist = table.Column<string>(maxLength: 5, nullable: true),
                    Weight = table.Column<string>(maxLength: 5, nullable: true),
                    Bust = table.Column<string>(maxLength: 5, nullable: true),
                    Cup = table.Column<int>(nullable: false),
                    AvailableTo = table.Column<string>(nullable: true),
                    BumpedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
