using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Transactions;
using Transaction_System.Data;

namespace Transaction_System.UseCases.UserUseCase.Commands.AttachmentCommand
{
    public class CreateAttachment
    {
        public record command : IRequest
        {
            public int Id { get; set; }
            public string ImageUrl { get; set; }
            public int TransactionId { get; set; }
        };
        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<command>
        {
            public async Task Handle(command request, CancellationToken cancellationToken)
            {
                var newAttachment = new Domain.Attachment
                {
                    ImageUrl = request.ImageUrl,
                    TransactionId = request.TransactionId
                };

                await context.AddAsync(newAttachment);
                await context.SaveChangesAsync();
            }
        }
    }
}
