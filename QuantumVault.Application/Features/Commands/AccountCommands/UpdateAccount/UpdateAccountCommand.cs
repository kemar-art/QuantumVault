﻿using MediatR;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Features.Commands.AccountCommands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int AccountNumber { get; set; }
        //public decimal Balance { get; set; }
        public decimal Deposit { get; set; }
    }
}
