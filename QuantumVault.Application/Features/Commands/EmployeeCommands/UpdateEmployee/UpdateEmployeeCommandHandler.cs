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

namespace QuantumVault.Application.Features.Commands.EmployeeCommands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmployee _employee;

        public UpdateEmployeeCommandHandler(IMapper mapper, IEmployee employee)
        {
            _mapper = mapper;
            _employee = employee;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateEmployeeCommandValidator(_employee);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Error submitting Employee for update", validationResult);
            }

            //Convert incoming entity to domain entity
            var employeeToUpdate = _mapper.Map<Employee>(request);
            //Add to database 
            await _employee.UpdateAsync(employeeToUpdate);

            //Return result.
            return Unit.Value;
        }
    }
}
