using Microsoft.EntityFrameworkCore.Migrations;

namespace TickabusWebApp.Migrations
{
    public partial class HashPasswordAddedUsersFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassWordSalt",
                table: "Users",
                newName: "PasswordSalt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Users",
                newName: "PassWordSalt");
        }
    }
}
