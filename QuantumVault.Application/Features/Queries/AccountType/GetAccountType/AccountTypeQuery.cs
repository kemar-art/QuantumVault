using MediatR;
using QuantumVault.Application.Features.Queries.Account.GetAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.AccountType.GetAccountType;

public record AccountTypeQuery(Guid Id) : IRequest<AccountTypeDTO>;

