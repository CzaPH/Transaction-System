using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;

namespace Transaction_System.UseCases.UserUseCase.Commands.AttachmentCommand
{
    public class UpdateAttachment
    {
        public record command(int Id, string ImageUrl, int TransactionId) : IRequest
        {
            public record Handler(DataContext context, IMapper mapper) : IRequestHandler<command>
            {
                public async Task Handle(command request, CancellationToken cancellationToken)
                {
                    var Attachment = await context.Attachment.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (Attachment is null)
                    {
                        //throw new NoUserExistException(request.Id.ToString());
                        throw new ArgumentException($"The Id '{request.Id}' is not found.");
                    }

                    Attachment.ImageUrl = request.ImageUrl;
                    Attachment.TransactionId = request.TransactionId;

                    await context.SaveChangesAsync();

                }
            }
        }
    }
}
