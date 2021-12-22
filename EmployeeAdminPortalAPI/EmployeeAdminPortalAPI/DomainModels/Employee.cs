using System;
namespace EmployeeAdminPortalAPI.DomainModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DesignationId { get; set; }
        public float Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string ProfileImageUrl { get; set; }

        public Designation Designation { get; set; }
        public Address Address { get; set; }
    }
}
