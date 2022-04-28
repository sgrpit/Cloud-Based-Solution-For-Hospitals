using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientManagement.API.Migrations
{
    public partial class UPdateColumnNameAppiontmentDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppintmentDate",
                table: "PatientAppointment",
                newName: "AppointmentDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "PatientAppointment",
                newName: "AppintmentDate");
        }
    }
}
