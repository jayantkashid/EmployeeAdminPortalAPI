using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeAdminPortalAPI.DataModels;

namespace EmployeeAdminPortalAPI.DataMapperRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int Id);
    }
}
