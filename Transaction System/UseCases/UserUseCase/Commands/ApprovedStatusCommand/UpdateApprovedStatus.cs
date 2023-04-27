using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;

namespace Transaction_System.UseCases.UserUseCase.Commands.ApprovedStatusCommand
{
    public class UpdateApprovedStatus
    {
        public record command(int Id, int UserId, bool Approved, int TransactionId) : IRequest
        {
            public record Handler(DataContext context, IMapper mapper) : IRequestHandler<command>
            {
                public async Task Handle(command request, CancellationToken cancellationToken)
                {
                    var Approved = await context.ApprovalStatus.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (Approved is null)
                    {
                        //throw new NoUserExistException(request.Id.ToString());
                        throw new ArgumentException($"The Id '{request.Id}' is not found.");
                    }

                    Approved.UserId = request.UserId;
                    Approved.Approved = request.Approved;
                    Approved.TransactionId = request.TransactionId;

                    await context.SaveChangesAsync();

                }
            }
        }
    }
}
