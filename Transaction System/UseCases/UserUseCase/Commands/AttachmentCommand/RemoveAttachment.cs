using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;

namespace Transaction_System.UseCases.UserUseCase.Commands.AttachmentCommand
{
    public class RemoveAttachment
    {
        public record command(int TransactionId) : IRequest
        {
            public record Handler(DataContext context, IMapper mapper) : IRequestHandler<command>
            {
                public async Task Handle(command request, CancellationToken cancellationToken)
                {
                    var attachment = await context.Attachment.FirstOrDefaultAsync(x => x.TransactionId == request.TransactionId);

                    if (attachment is not null)
                    {
                        if (!attachment.IsDeleted)
                        {
                            attachment.IsDeleted = true;
                    var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.TransactionId);
                            transaction.IsDeleted = true;
                            await context.SaveChangesAsync();

                        }
                        else
                        {
                            // Attachment is already marked as deleted
                            throw new Exception("Id is already deleted");
                        }
                    }
                    else
                    {
                        // Transaction ID not found in the database
                        throw new Exception("Id not found");
                    }


                }
            }
        }
    }
}
