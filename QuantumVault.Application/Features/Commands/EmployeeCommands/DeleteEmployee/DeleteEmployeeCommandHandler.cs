using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.EmployeeCommands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IEmployee _employee;

        public DeleteEmployeeCommandHandler(IEmployee employee)
        {
            _employee = employee;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            //Find the Employe to be deleted
            var formToDelete = await _employee.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (formToDelete is null)
            {
                throw new NotFoundException(nameof(DeleteEmployeeCommand), request.Id);
            }

            //remove the record from the database 
            await _employee.DeleteAsync(formToDelete);

            //Return result.+
            return Unit.Value;
        }
    }
}
