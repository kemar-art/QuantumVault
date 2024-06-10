using AutoMapper;
using Moq;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Features.Queries.CustomerQuery.GetCustomer;
using QuantumVault.Domain;
using Xunit;

namespace TestProject
{
    public class CustomerQueryHandlerTests
    {
        [Fact]
        public async Task Handle_WithValidEmail_ReturnsCustomerWithAllAccounts()
        {
            // Arrange
            var mockRepo = new Mock<ICustomerRepository>();
            var mockMapper = new Mock<IMapper>();


            var customer = new Customer
            {
                Email = "test@example.com",
                Accounts = new List<Account>
            {
                new Account { AccountNumber = 12345 },
                new Account { AccountNumber = 67890 }
            }
            };

            mockRepo.Setup(repo => repo.GetByEmailAsync("test@example.com")).ReturnsAsync(customer);

            var customerDto = new CustomerDTO
            {
                Email = "test@example.com",
                Accounts =
            [
                new CustomerAccountDTO { AccountNumber = 12345 },
                new CustomerAccountDTO { AccountNumber = 67890 }
            ]
            };

            mockMapper.Setup(m => m.Map<CustomerDTO>(It.IsAny<Customer>())).Returns(customerDto);

            var handler = new CustomerQueryHandler(mockRepo.Object, mockMapper.Object);
            var query = new CustomerQuery("test@example.com", 0);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Accounts.Count);
        }
    }

}
