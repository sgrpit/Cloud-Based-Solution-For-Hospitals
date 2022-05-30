using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.DTOs
{
    public class AddDepartmentReqDto
    {
        public string DepartmentName { get; set; }
        public string DepartmentDesc { get; set; }

    }

    public class DepartmentResDto
    {
        public Guid Id { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDesc { get; set; }
    }
}
