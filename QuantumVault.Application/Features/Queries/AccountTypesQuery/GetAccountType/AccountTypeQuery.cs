using MediatR;
using QuantumVault.Application.Features.Queries.AccountTypeQuery.GetAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.AccountTypeQuery.GetAccountType;

public record AccountTypeQuery(Guid Id) : IRequest<AccountTypeDTO>;

