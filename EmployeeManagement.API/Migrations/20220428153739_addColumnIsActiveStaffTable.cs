using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.API.Migrations
{
    public partial class addColumnIsActiveStaffTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StaffDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StaffDetails");
        }
    }
}
