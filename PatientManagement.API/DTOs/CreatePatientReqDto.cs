using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.DTOs
{
    public class CreatePatientReqDto
    {
        public string PatientUHID { get; set; }
        public string PatientName { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PatientType { get; set; }
    }
}
