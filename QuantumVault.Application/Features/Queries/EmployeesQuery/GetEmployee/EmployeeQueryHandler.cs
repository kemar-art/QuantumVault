using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.EmployeesQuery.GetEmployee
{
    public class EmployeeQueryHandler : IRequestHandler<EmployeeQuery, EmployeeDTO>
    {
        private readonly IMapper _mapper;
        private readonly IEmployee _employee;

        public EmployeeQueryHandler(IMapper mapper, IEmployee employee)
        {
            _mapper = mapper;
            _employee = employee;
        }

        public async Task<EmployeeDTO> Handle(EmployeeQuery request, CancellationToken cancellationToken)
        {
            //Querying the database
            var getEmployee = await _employee.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (getEmployee is null)
            {
                throw new NotFoundException(nameof(EmployeeQuery), request.Id);
            }

            //Mapping the object from the Database to the Dto
            var mapData = _mapper.Map<EmployeeDTO>(getEmployee);

            return mapData;
        }
    }
}
