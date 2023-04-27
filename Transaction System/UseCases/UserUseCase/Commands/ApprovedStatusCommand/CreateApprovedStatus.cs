using AutoMapper;
using MediatR;
using Transaction_System.Data;

namespace Transaction_System.UseCases.UserUseCase.Commands.ApprovedStatusCommand
{
    public static class CreateApprovedStatus
    {
        public record command : IRequest
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public bool Approved { get; set; }
            public int TransactionId { get; set; }
        };
        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<command>
        {
            public async Task Handle(command request, CancellationToken cancellationToken)
            {
                var newApprovedStatus = new Domain.ApprovalStatus
                {
                    UserId = request.UserId,
                    Approved = request.Approved,
                    TransactionId = request.TransactionId

                };

                await context.AddAsync(newApprovedStatus);
                await context.SaveChangesAsync();
            }
        }
    }
}
