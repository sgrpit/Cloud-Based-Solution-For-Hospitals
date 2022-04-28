using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientManagement.API.Migrations
{
    public partial class AddColumnContactNoToAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "PatientAppointment",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "PatientAppointment");
        }
    }
}
