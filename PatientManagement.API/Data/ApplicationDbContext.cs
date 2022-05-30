using Microsoft.EntityFrameworkCore;
using PatientManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<PatientAppointment> PatientAppointment { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Department_1> Department_1 { get; set; }

    }
}
