using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        //DbContext
        public DataContext() : base("name=DataContext") { }

        public DbSet<ServiceRequest> ServiceRequest { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Program> Program { get; set; }
    }
}