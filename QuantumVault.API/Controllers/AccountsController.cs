using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuantumVault.Application.Contracts.Repository_Interface;
using QuantumVault.Application.Features.Commands.AccountCommands.UpdateAccount;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuantumVault.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMediator _mediator;

        public AccountsController(IAccountRepository accountRepository, IMediator mediator)
        {
            _accountRepository = accountRepository;
            _mediator = mediator;
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id},{accountNumber},{depositAmount}")]
        public async Task<ActionResult> Put(/*int? accountNumber, decimal depositAmount*/ UpdateAccountCommand updateAccount)
        {
            //await _mediator.Send(new UpdateAccountCommand(accountNumber, depositAmount));
            await _mediator.Send(updateAccount);
            return NoContent();
        }

    }
}
