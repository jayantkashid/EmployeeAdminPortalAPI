using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAdminPortalAPI.DataConnection;
using EmployeeAdminPortalAPI.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortalAPI.DataMapperRepositories
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeAdminContext context;
        public SqlEmployeeRepository(EmployeeAdminContext context)
        {
            this.context = context;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await context.Employee.Include(nameof(Designation)).Include(nameof(Address)).ToListAsync();
        }

        public async Task<Employee> GetEmployee(int Id)
        {
            return await context.Employee.Include(nameof(Designation)).Include(nameof(Address)).FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
