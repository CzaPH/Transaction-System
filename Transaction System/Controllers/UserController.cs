using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.DataAnnotations;
using Transaction_System.Data;
using Transaction_System.Domain;
using Transaction_System.UseCases.UserUseCase.Queries;

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


    }

}

