using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientManagement.API.Migrations
{
    public partial class AddPatientappointmenttable_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAppointmentHistory");

            migrationBuilder.CreateTable(
                name: "PatientAppointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientGuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientUHID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppintmentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentTimeSlot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiagnosisDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAppointment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAppointment");

            migrationBuilder.CreateTable(
                name: "PatientAppointmentHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppintmentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentTimeSlot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiagnosisDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientGuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAppointmentHistory", x => x.Id);
                });
        }
    }
}
