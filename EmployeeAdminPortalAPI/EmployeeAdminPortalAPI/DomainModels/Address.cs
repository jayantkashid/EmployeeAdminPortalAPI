using System;
namespace EmployeeAdminPortalAPI.DomainModels
{
    public class Address
    {
        public int Id { get; set; }
        public string PriAddress { get; set; }
        public string SecAddress { get; set; }

        //Navigation Property
        public int EmployeeId { get; set; }
    }
}
