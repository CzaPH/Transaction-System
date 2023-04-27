using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;
using Transaction_System.Domain;
using Transaction_System.Shared.Enum;

namespace Transaction_System.UseCases.UserUseCase.Commands.TransactionCommand
{
    public static class UpdateTransaction
    {
        public record command (int Id, string Description, double Amount, int ToAccountId, UserType Type, int FromAccountId) : IRequest
        {
            public record Handler(DataContext context, IMapper mapper) : IRequestHandler<command>
            {
                public async Task Handle(command request, CancellationToken cancellationToken)
                {
                    var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (transaction is null)
                    {
                        throw new ArgumentException($"The Id '{request.Id}' is not found.");
                    }
                    transaction.Description = request.Description;
                    transaction.Amount = (decimal)request.Amount;
                    transaction.ToAccountId = request.ToAccountId;
                    transaction.Type = (TransactionType)request.Type;
                    transaction.FromAccountId = request.FromAccountId;

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
