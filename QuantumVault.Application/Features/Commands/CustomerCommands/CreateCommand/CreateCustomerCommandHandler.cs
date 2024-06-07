using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
using QuantumVault.Application.StaticDetails;
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
        private readonly ICustomerRepository _customer;
        private readonly IAccountRepository _account;
        private readonly IBranchRepository _branch;
        private readonly ITransactionRepository _transaction;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customer, IAccountRepository account, IBranchRepository branch, ITransactionRepository transaction)
        {
            _mapper = mapper;
            _customer = customer;
            _account = account;
            _branch = branch;
            _transaction = transaction;
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



            //Create Branch
            Branch branch = null;
            if (await _branch.GetBranchCountAsync() <= 1)
            {
                // This should be seeded in database after which I will use a query here instead of hard coding it
                branch = new()
                {
                    Id = new Guid("f219f041-ab3d-4785-8f07-aca7ca73e39e"),
                    BranchName = "Current Branch",
                    Address = "Current Address",
                    PhoneNumber = "876-000-0000"
                };
            }

            //Create an Account for the customer
            Account account = new()
            {
                CustomerId = customerToCreate.Id,
                Balance = customerToCreate.OpeningBalance,
                CreatedDate = DateTime.Now,
                BranchId = branch.Id,
            };
            await _account.CreateAsync(account);

            TransactionType transactionType = new()
            {
                Id = new Guid("f219f041-ab3d-4785-8f07-a7a77a73739e"),
                TypeName = "Deposit"
            };
            
            //Log Transaction
            Transaction transaction = new()
            {
                Amount = customerToCreate.OpeningBalance,
                Description = $"{customerToCreate.FirstName} {customerToCreate.LastName} thank you for opening a new account with us.",
                TransactionDate = DateTime.Now,
                AccountId = account.Id,
                // The Transaction Type should be added.
                TransactionTypeId = transactionType.Id

            };
            await _transaction.CreateAsync(transaction);

            //Log to AuditLog Table
            AuditLog auditLog = new()
            {

            };

            //Return result.
            return customerToCreate.Id;
        }
    }
}
