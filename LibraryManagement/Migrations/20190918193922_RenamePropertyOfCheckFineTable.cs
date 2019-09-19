using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Migrations
{
    public partial class RenamePropertyOfCheckFineTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookKeepingDays",
                table: "CheckFines",
                newName: "DelayDays");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DelayDays",
                table: "CheckFines",
                newName: "BookKeepingDays");
        }
    }
}
