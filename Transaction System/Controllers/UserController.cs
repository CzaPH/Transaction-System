using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.DataAnnotations;
using Transaction_System.Data;
using Transaction_System.Domain;
using Transaction_System.UseCases.UserUseCase.Commands.UpdateUserCredential;
using Transaction_System.UseCases.UserUseCase.Queries;
using static Transaction_System.UseCases.UserUseCase.Commands.UpdateUserCredential.UpdateUserCommand;
using static Transaction_System.UseCases.UserUseCase.Commands.UpdateUserCredentials.DeleteUserCommand;

namespace Transaction_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult>  Query(int Id)
        {
            var query = new GetUserById.Query(Id);
            var results = await _mediator.Send(query);

            return Ok(results);
        }
        [HttpGet]
        public async Task<IActionResult> Query()
        {
            var query = new GetUsers.Query();
            var results = await _mediator.Send(query);

            return Ok(results);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandData command)
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
        [HttpDelete]
        public async Task<IActionResult> RemoveUser([FromBody] Command command)
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


    }

}

