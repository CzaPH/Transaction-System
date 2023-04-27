﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transaction_System.UseCases.UserUseCase.Commands.AttachmentCommand;
using Transaction_System.UseCases.UserUseCase.Queries.AttachmentQuery;


namespace Transaction_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AttachmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttachment([FromBody] CreateAttachment.command command)
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
            var query = new GetAttachment.Query();
            var results = await _mediator.Send(query);

            return Ok(results);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Query(int Id)
        {
            var query = new GetAttachmentById.Query(Id);
            var results = await _mediator.Send(query);

            return Ok(results);
        }
    }
}
