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

namespace QuantumVault.Application.Features.Queries.CustomerQuery.GetCustomer
{

    public class CustomerQueryHandler : IRequestHandler<CustomerQuery, CustomerDTO>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Handle(CustomerQuery request, CancellationToken cancellationToken)
        {
            Customer? getCustomer = null;

            if (!string.IsNullOrEmpty(request.email))
            {
                // Query by Email
                getCustomer = await _customerRepository.GetByEmailAsync(request.email);
            }
            else if (request.accountAccount != 0)
            {
                // Query by Account Number
                getCustomer = await _customerRepository.GetByAccountNumberAsync(request.accountAccount);
            }

            // Verify if the record exists
            if (getCustomer is null)
            {
                throw new NotFoundException(nameof(Customer), request.accountAccount);
            }

            // Mapping the object from the Database to the DTO
            var mapData = _mapper.Map<CustomerDTO>(getCustomer);

            return mapData;
        }
    }


    //public class CustomerQueryHandler : IRequestHandler<CustomerQuery, CustomerDTO>
    //{
    //    private readonly IMapper _mapper;
    //    private readonly ICustomerRepository _customerRepository;
    //    private readonly IAccountRepository _accountRepository;

    //    public CustomerQueryHandler(IMapper mapper, ICustomerRepository customer, IAccountRepository account)
    //    {
    //        _mapper = mapper;
    //        _customerRepository = customer;
    //        _accountRepository = account;
    //    }

    //    public async Task<CustomerDTO> Handle(CustomerQuery request, CancellationToken cancellationToken)
    //    {
    //        Customer getCustomer = null;

    //        if (request.account.CustomerId != null)
    //        {
    //            // Query by ID
    //            getCustomer = await _customerRepository.GetByIdAsync(request.account.CustomerId);
    //        }
    //        else if (!string.IsNullOrEmpty(request.account?.Customer?.Email))
    //        {
    //            // Query by Email
    //            getCustomer = await _customerRepository.GetByEmailAsync(request.account.Customer.Email);
    //        }
    //        else if (request.account?.AccountNumber != null)
    //        {
    //            // Query by Account Number

    //                getCustomer = await _customerRepository.GetByAccountIdAsync(request.account.AccountNumber);
    //        }

    //        // Verify if the record exists
    //        if (getCustomer is null)
    //        {
    //            throw new NotFoundException(nameof(CustomerQuery), request);
    //        }

    //        // Mapping the object from the Database to the Dto
    //        var mapData = _mapper.Map<CustomerDTO>(getCustomer);

    //        return mapData;
    //    }
    //}
}
