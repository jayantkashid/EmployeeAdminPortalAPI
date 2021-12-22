using System;
using AutoMapper;
using DataModels = EmployeeAdminPortalAPI.DataModels;
using EmployeeAdminPortalAPI.DomainModels;


namespace EmployeeAdminPortalAPI.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Employee, Employee>().ReverseMap();
            CreateMap<DataModels.Address, Address>().ReverseMap();
            CreateMap<DataModels.Designation, Designation>().ReverseMap();
        }
    }
}
