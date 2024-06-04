using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.CardTypeCommands.CreateCardType
{
    public class CreateCardTypeCommand : IRequest<Guid>
    {
        public string CardTypeName { get; set; } = string.Empty;
    }
}
