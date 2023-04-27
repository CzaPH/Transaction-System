using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;

namespace Transaction_System.UseCases.UserUseCase.Commands.AttachmentCommand
{
    public class RemoveAttachment
    {
        public record command(int Id) : IRequest
        {
            public record Handler(DataContext context, IMapper mapper) : IRequestHandler<command>
            {
                public async Task Handle(command request, CancellationToken cancellationToken)
                {
                    var account = await context.Attachment.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (account is not null)
                    {
                        account.IsDeleted = true;
                        await context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
