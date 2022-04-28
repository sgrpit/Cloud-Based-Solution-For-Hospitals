using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.DTOs
{
    public class UpdateStaffReqDto
    {
        public Guid StaffGuid { get; set; }
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
    }
}
