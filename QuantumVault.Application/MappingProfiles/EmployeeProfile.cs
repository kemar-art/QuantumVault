using AutoMapper;
using QuantumVault.Application.Features.Queries.EmployeesQuery.GetAllEmployees;
using QuantumVault.Application.Features.Queries.EmployeesQuery.GetEmployee;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Employee, AllEmployeesDTO>();
            //CreateMap<Employee, EmployeeDTO>();
            //CreateMap<Employee, EmployeeDTO>();
        }
    }
}
