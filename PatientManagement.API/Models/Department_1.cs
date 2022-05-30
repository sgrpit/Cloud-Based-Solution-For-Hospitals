using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.Models
{
    public class Department_1
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
    }
}
