using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.DTOs
{
    public class AppointmentReqDto
    {
        public Guid PatientGuid { get; set; }
        public string PatientName { get; set; }
        public string PatientUHID { get; set; }
        public string ContactNo { get; set; }
        public string City { get; set; }
        public string DateOfBirth { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTimeSlot { get; set; }
        public string BloodGroup { get; set; }
        public string EmployeeId { get; set; }
        public string DiagnosisDetails { get; set; }
    }

    public class AppointmentResDto
    {
        public Guid PatientGuid { get; set; }
        public string PatientUHID { get; set; }
        public string PatientName { get; set; }
        public string ContactNo { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTimeSlot { get; set; }
        public string EmployeeId { get; set; }
    }
}
