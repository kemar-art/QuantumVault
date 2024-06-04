using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.EmployeeCommands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IEmployee _employee;

        public CreateEmployeeCommandHandler(IMapper mapper, IEmployee employee)
        {
            _mapper = mapper;
            _employee = employee;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateEmployeeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Error submitting Employee for creation", validationResult);
            }

            //Convert incoming entity to domain entity
            var employeeToCreate = _mapper.Map<Employee>(request);

            //Add to database 
            await _employee.CreateAsync(employeeToCreate);

            //Return result.
            return employeeToCreate.Id;
        }
    }
}
