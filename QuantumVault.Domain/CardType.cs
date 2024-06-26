﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumVault.Domain;

public class CardType
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CardTypeName { get; set; } = string.Empty;
    public ICollection<Card>? Cards { get; set; }
}
