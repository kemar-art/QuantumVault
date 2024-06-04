using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Exceptions;
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
        private readonly ICustomer _customer;

        public CustomerQueryHandler(IMapper mapper, ICustomer customer)
        {
            _mapper = mapper;
            _customer = customer;
        }

        public async Task<CustomerDTO> Handle(CustomerQuery request, CancellationToken cancellationToken)
        {
            //Querying the database
            var getCustomer= await _customer.GetByIdAsync(request.Id);

            //Verify if the record exist
            if (getCustomer is null)
            {
                throw new NotFoundException(nameof(CustomerQuery), request.Id);
            }

            //Mapping the object from the Database to the Dto
            var mapData = _mapper.Map<CustomerDTO>(getCustomer);

            return mapData;
        }
    }
}
