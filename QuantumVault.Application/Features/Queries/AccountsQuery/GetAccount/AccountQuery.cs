using MediatR;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.AccountsQuery.GetAccount
{
    public record AccountQuery(Guid Id) : IRequest<AccountDTO>;

}
