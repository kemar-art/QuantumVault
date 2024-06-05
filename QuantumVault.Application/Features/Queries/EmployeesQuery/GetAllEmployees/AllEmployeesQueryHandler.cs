using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.EmployeesQuery.GetAllEmployees
{
    public class AllEmployeesQueryHandler : IRequestHandler<AllEmployeesQuery, IEnumerable<AllEmployeesDTO>>
    {
        private readonly IEmployeeRepository _employee;
        private readonly IMapper _mapper;

        public AllEmployeesQueryHandler(IMapper mapper, IEmployeeRepository employee)
        {
            _employee = employee;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AllEmployeesDTO>> Handle(AllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var getAllEmployees = await _employee.GetAllAsync();

            var mapData = _mapper.Map<IEnumerable<AllEmployeesDTO>>(getAllEmployees);

            return mapData;
        }
    }
}
