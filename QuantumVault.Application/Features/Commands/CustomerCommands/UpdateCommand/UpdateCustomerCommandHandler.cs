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

namespace QuantumVault.Application.Features.Commands.CustomerCommands.UpdateCommand
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customer;

        public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customer)
        {
            _mapper = mapper;
            _customer = customer;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateCustomerCommandValidator(_customer);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Error submitting Customer for update", validationResult);
            }

            //Convert incoming entity to domain entity
            var customerToUpdate = _mapper.Map<Customer>(request);
            //Add to database 
            await _customer.UpdateAsync(customerToUpdate);

            //Return result.
            return Unit.Value;
        }
    }
}
