using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.Models
{
    public class PatientAppointmentHistory
    {
        [Key]
        public Guid Id { get; set; }
        public string PatientGuid { get; set; }
        public string PatientUHID { get; set; }
        public string AppintmentDate { get; set; }
        public string AppointmentTimeSlot { get; set; }
        public string EmployeeId { get; set; }
        public string DiagnosisDetails { get; set; }
        public string AppointmentType { get; set; }
        public string ReportId { get; set; }
    }
}
