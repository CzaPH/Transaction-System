using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transaction_System.UseCases.UserUseCase.Commands.AccountCommand;
using Transaction_System.UseCases.UserUseCase.Commands.ApprovedStatusCommand;
using Transaction_System.UseCases.UserUseCase.Queries.ApprovedStatusQuery;
using Transaction_System.UseCases.UserUseCase.Queries.AttachmentQuery;

namespace Transaction_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovedStatus : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApprovedStatus(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateApprovedStatus([FromBody] CreateApprovedStatus.command command)
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
            var query = new GetApprovedStatus.Query();
            var results = await _mediator.Send(query);

            return Ok(results);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Query(int Id)
        {
            var query = new GetApprovedStatusById.Query(Id);
            var results = await _mediator.Send(query);

            return Ok(results);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateApprovedStatus([FromBody] UpdateApprovedStatus.command command)
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
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveApprovedStatus(int Id)
        {
            try
            {
                await _mediator.Send(new RemoveApprovedStatus.command(Id));
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
