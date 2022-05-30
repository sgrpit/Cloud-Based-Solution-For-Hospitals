using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Models
{
    public class Department
    {
        [Key]        
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDesc { get; set; }

        public ICollection<Staff> Staffs { get; set; }
    }
}
