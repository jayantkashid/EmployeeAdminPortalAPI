using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeAdminPortalAPI.DataMapperRepositories;
using EmployeeAdminPortalAPI.DomainModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAdminPortalAPI.Controllers
{
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;
        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        // GET: /<controller>/
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllEmployees()
        {
            //exposing data model directly here -
            //return Ok(employeeRepository.GetEmployees());

            // expose doamin models and hide data models using DTOs /domain models
            var employees = await employeeRepository.GetEmployees();

            /*
             * Code to get employees with DTOs but without using Automapper.
            //var domainEmployees = new List<Employee>();
            //foreach(var employee in employees)
            //{
            //    domainEmployees.Add(new Employee
            //    {
            //        Id = employee.Id,
            //        Name = employee.Name,
            //        DesignationId = employee.DesignationId,
            //        Salary = employee.Salary,
            //        JoiningDate = employee.JoiningDate,
            //        Email = employee.Email,
            //        Mobile = employee.Mobile,
            //        ProfileImageUrl = employee.ProfileImageUrl,
            //        Address = new Address
            //        {
            //            Id = employee.Address.Id,
            //            PriAddress = employee.Address.PriAddress,
            //            SecAddress = employee.Address.SecAddress,
            //            EmployeeId = employee.Address.EmployeeId,
            //        },
            //        Designation = new Designation
            //        {
            //            Id = employee.Designation.Id,
            //            Description = employee.Designation.Description,
            //        },
            //    });
            //}
            //return Ok(domainEmployees);

            */
            return Ok(mapper.Map<List<Employee>>(employees));
        }
    }
}
