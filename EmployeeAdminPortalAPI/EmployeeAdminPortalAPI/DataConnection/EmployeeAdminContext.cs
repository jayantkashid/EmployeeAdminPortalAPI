using System;
using EmployeeAdminPortalAPI.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortalAPI.DataConnection
{
    public class EmployeeAdminContext : DbContext
    {
        public EmployeeAdminContext(DbContextOptions<EmployeeAdminContext> options):base (options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Designation> Designation { get; set; }
    }
}
