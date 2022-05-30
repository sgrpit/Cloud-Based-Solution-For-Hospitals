using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Models
{
    public class Staff
    {
        [Key]
        public Guid Id { get; set; }
        public string StaffId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string BloodGroup { get; set; }
        public string DateOfBirth { get; set; }
        public int RoleId { get; set; }
        public bool IsPermanent { get; set; }
        
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("FK_Department")]
        public int DepartmentId { get; set; }
        
        public Department Departments { get; set; }
    }
}
