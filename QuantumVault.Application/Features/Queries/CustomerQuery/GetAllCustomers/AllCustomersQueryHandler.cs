using AutoMapper;
using MediatR;
using QuantumVault.Application.Contracts.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.CustomerQuery.GetAllCustomers
{
    public class AllCustomersQueryHandler : IRequestHandler<AllCustomersQuery, IEnumerable<AllCustomersDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customer;

        public AllCustomersQueryHandler(IMapper mapper, ICustomerRepository customer)
        {
            _mapper = mapper;
            _customer = customer;
        }

        public async Task<IEnumerable<AllCustomersDTO>> Handle(AllCustomersQuery request, CancellationToken cancellationToken)
        {
            var getAllCustomers = await _customer.GetAllAsync();

            var mapData = _mapper.Map<IEnumerable<AllCustomersDTO>>(getAllCustomers);

            return mapData;
        }
    }
}
