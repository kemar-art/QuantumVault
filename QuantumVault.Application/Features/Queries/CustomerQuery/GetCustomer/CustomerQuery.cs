using MediatR;
using QuantumVault.Application.Features.Queries.AccountsQuery.GetAccount;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.CustomerQuery.GetCustomer
{
    public record CustomerQuery(string? email, int accountAccount) : IRequest<CustomerDTO>;

}
