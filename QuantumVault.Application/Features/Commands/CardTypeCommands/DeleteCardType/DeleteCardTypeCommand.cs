using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CardTypeCommands.DeleteCardType
{
    public class DeleteCardTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
