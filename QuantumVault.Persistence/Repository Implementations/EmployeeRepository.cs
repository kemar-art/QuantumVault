﻿using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Domain;
using QuantumVault.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Persistence.Repository_Implementations
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(QuantumVaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}
