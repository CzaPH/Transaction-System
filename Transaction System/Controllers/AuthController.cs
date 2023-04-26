using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transaction_System.UseCases.UserUseCase.Commands.Authentication;
using static Transaction_System.UseCases.UserUseCase.Commands.Authentication.SignUp;

namespace Transaction_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUp.SignUpCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignIn.SignInCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [Authorize]
        [HttpPost("signout")]
        public IActionResult Logout()
        {
            return Ok("test");
        }
    }
}
