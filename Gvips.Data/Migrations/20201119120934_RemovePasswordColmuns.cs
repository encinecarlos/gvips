using Microsoft.EntityFrameworkCore.Migrations;

namespace Gvips.Data.Migrations
{
    public partial class RemovePasswordColmuns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SaltPassword",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
