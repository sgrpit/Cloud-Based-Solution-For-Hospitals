using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.Models
{
    public class Patient
    {
        [Key]
        public Guid ID { get; set; }
        public string PatientUHID { get; set; }
        public string PatientName { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PatientType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; } = DateTime.Now;

    }
}
