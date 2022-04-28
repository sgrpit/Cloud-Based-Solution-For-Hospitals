using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientManagement.API.Migrations
{
    public partial class updatedpatientappointtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "PatientAppointmentHistory",
                newName: "PatientUHID");

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "PatientAppointmentHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "PatientAppointmentHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "PatientAppointmentHistory",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "PatientAppointmentHistory");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "PatientAppointmentHistory");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "PatientAppointmentHistory");

            migrationBuilder.RenameColumn(
                name: "PatientUHID",
                table: "PatientAppointmentHistory",
                newName: "ReportId");
        }
    }
}
