using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.DTOs
{
    public class CreateStaffReqDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public int RoleId { get; set; }
        public string Ispermanent { get; set; }
        public string DateOfBirth { get; set; }
    }

    public class CreateStaffResDto
    {
        public string StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public int RoleId { get; set; }
        public string Ispermanent { get; set; }
        public string DateOfBirth { get; set; }
    }
}
