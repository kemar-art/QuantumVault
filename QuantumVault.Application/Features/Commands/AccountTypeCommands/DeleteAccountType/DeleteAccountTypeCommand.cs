﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountTypeCommands.DeleteAccountType
{
    public class DeleteAccountTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
