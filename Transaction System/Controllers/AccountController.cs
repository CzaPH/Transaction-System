﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transaction_System.UseCases.UserUseCase.Commands.AccountCommand;
using Transaction_System.UseCases.UserUseCase.Commands.UpdateUserCredentials;
using Transaction_System.UseCases.UserUseCase.Queries.AccountQuery;
using static Transaction_System.UseCases.UserUseCase.Commands.UpdateUserCredential.UpdateUserCommand;

namespace Transaction_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccount.Command command)
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
            var query = new GetAccount.Query();
            var results = await _mediator.Send(query);

            return Ok(results);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Query(int Id)
        {
            var query = new GetAccountById.Query(Id);
            var results = await _mediator.Send(query);

            return Ok(results);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccount.command command)
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
        public async Task<IActionResult> RemoveAccount(int Id)
        {
            try
            {
                await _mediator.Send(new RemoveAccount.command(Id));
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
