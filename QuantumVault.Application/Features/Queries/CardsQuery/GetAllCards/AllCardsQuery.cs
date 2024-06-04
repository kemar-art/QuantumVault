using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Queries.CardsQuery.GetAllCards
{
    public record AllCardsQuery : IRequest<IEnumerable<AllCardsDTO>>;

}
