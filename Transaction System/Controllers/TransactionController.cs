using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transaction_System.UseCases.UserUseCase.Commands.Authentication;
using Transaction_System.UseCases.UserUseCase.Commands.TransactionCommand;
using Transaction_System.UseCases.UserUseCase.Queries.AccountQuery;
using Transaction_System.UseCases.UserUseCase.Queries.TransactionQuery;

namespace Transaction_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransaction.command command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        [HttpGet]
        public async Task<IActionResult> Query()
        {
            var query = new GetTransaction.Query();
            var results = await _mediator.Send(query);

            return Ok(results);
        }
        [HttpGet("{Id})")]
        public async Task<IActionResult> Query(int Id)
        {
            var query = new GetTransactionById.Query(Id);
            var results = await _mediator.Send(query);

            return Ok(results);
        }
    }
}
