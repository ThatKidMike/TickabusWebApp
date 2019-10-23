using Microsoft.EntityFrameworkCore.Migrations;

namespace TickabusWebApp.Migrations
{
    public partial class TicketsChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationCity",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartingCity",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationCity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "StartingCity",
                table: "Tickets");
        }
    }
}
