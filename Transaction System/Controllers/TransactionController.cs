﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transaction_System.UseCases.UserUseCase.Commands.AccountCommand;
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
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransaction.Command command)
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
        [HttpPut]
        public async Task<IActionResult> UpdateTransaction([FromBody] UpdateTransaction.command command)
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
        public async Task<IActionResult> RemoveTransaction(int Id)
        {
            try
            {
                await _mediator.Send(new RemoveTransaction.command(Id));
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
