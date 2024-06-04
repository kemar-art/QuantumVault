using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CardTypeCommands.UpdateCardType
{
    public class UpdateCardTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string CardTypeName { get; set; } = string.Empty;
    }
}
