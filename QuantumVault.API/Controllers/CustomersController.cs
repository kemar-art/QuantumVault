using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuantumVault.Application.Features.Commands.CustomerCommands.CreateCommand;
using QuantumVault.Application.Features.Commands.CustomerCommands.DeleteCustomer;
using QuantumVault.Application.Features.Commands.CustomerCommands.UpdateCommand;
using QuantumVault.Application.Features.Queries.CustomerQuery.GetAllCustomers;
using QuantumVault.Application.Features.Queries.CustomerQuery.GetCustomer;
using QuantumVault.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuantumVault.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IEnumerable<AllCustomersDTO>> Get()
        {
            var getAllCustomer = await _mediator.Send(new AllCustomersQuery());
            return getAllCustomer;
        }

        // GET api/<CustomersController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CustomerDTO>> Get(Guid id)
        //{
        //    var getCustomer = await _mediator.Send(new CustomerQuery(id));
        //    return Ok(getCustomer);
        //}
        [HttpGet("search")]
        public async Task<ActionResult<CustomerDTO>> Get(string? email, int accountNumber)
        {
            // Send the query to the mediator
            var getCustomer = await _mediator.Send(new CustomerQuery(email, accountNumber));
            return Ok(getCustomer);
        }


        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult> Post(CreateCustomerCommand createCustomer)
        {
            var createNewCustomer = await _mediator.Send(createCustomer);
            return CreatedAtAction(nameof(Get), new { id = createNewCustomer });
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(UpdateCustomerCommand updateCustomer)
        {
            await _mediator.Send(updateCustomer);
            return NoContent();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteCustomer = new DeleteCustomerCommand { Id = id };
            await _mediator.Send(deleteCustomer);
            return NoContent();
        }
    }
}
