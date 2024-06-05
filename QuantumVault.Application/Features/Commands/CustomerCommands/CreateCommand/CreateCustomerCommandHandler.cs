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

namespace QuantumVault.Application.Features.Commands.CustomerCommands.CreateCommand
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICustomer _customer;
        private readonly IAccountRepository _account;
        private readonly IBranchRepository _branch;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomer customer, IAccountRepository account, IBranchRepository branch)
        {
            _mapper = mapper;
            _customer = customer;
            _account = account;
            _branch = branch;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Error submitting Customer for creation", validationResult);
            }

            //Convert incoming entity to domain entity
            var customerToCreate = _mapper.Map<Customer>(request);

            //Add to database 
            await _customer.CreateAsync(customerToCreate);

            //Create an Account for the customer
            Account account = new()
            {
                CustomerId = customerToCreate.Id,
                Balance = customerToCreate.OpeningBalance,
                CreatedDate = DateTime.UtcNow,
                BranchId = customerToCreate.BranchId,
            };
            await _account.CreateAsync(account);

            //Return result.
            return customerToCreate.Id;
        }
    }
}
