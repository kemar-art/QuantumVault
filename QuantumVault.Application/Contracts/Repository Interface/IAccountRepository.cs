﻿using QuantumVault.Application.Features.Queries.CustomerQuery.GetCustomer;
using QuantumVault.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Application.Contracts.Repository_Interface
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<int> GetByAccountNumberAsync(int accountNumber);
        Task<Account> UpdateCustomerAccount(Guid? id, int? accountNumber, decimal? depositAmount);
    }
}
