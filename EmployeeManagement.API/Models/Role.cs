using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Models
{
    public class Role
    {
        public Int32 Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
    }
}
