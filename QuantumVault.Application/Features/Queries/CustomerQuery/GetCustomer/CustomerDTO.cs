using QuantumVault.Domain;

namespace QuantumVault.Application.Features.Queries.CustomerQuery.GetCustomer
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal OpeningBalance { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<CustomerAccountDTO> Accounts { get; set; } = [];
    }
}
