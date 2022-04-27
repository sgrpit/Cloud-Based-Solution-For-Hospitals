using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.DTOs
{
    public class CreatePatientReqDto
    {
        public string PatientUHID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
    }
}
