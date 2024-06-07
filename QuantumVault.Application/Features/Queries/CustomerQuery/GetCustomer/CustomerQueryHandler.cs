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
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customer;

        public CustomerQueryHandler(IMapper mapper, ICustomerRepository customer)
        {
            _mapper = mapper;
            _customer = customer;
        }

        public async Task<CustomerDTO> Handle(CustomerQuery request, CancellationToken cancellationToken)
        {
            Customer getCustomer = null;

            if (request.Id.HasValue)
            {
                // Query by ID
                getCustomer = await _customer.GetByIdAsync(request.Id.Value);
            }
            else if (!string.IsNullOrEmpty(request.Email))
            {
                // Query by Email
                //getCustomer = await _customer.GetByEmailAsync(request.Email);
            }
            else if (!string.IsNullOrEmpty(request.AccountNumber))
            {
                // Query by Account Number
               // getCustomer = await _customer.GetByAccountNumberAsync(request.AccountNumber);
            }

            // Verify if the record exists
            if (getCustomer is null)
            {
                throw new NotFoundException(nameof(CustomerQuery), request);
            }

            // Mapping the object from the Database to the Dto
            var mapData = _mapper.Map<CustomerDTO>(getCustomer);

            return mapData;
        }
    }
}
