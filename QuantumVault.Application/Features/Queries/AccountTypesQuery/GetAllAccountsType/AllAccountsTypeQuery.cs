using MediatR;


namespace QuantumVault.Application.Features.Queries.AccountTypeQuery.GetAllAccountsType
{
    public record AllAccountsTypeQuery : IRequest<IEnumerable<AllAccountsTypeDTO>>;
}
