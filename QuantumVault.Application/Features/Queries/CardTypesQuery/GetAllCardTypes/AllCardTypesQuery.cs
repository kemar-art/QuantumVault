using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.CardTypesQuery.GetAllCardTypes
{
    public record AllCardTypesQuery : IRequest<IEnumerable<AllCardTypesDTO>>;

}
