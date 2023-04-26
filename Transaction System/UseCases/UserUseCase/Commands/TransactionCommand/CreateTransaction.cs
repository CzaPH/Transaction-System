using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;
using Transaction_System.Domain;
using Transaction_System.Shared.Enum;


namespace Transaction_System.UseCases.UserUseCase.Commands.TransactionCommand
{
    public static class CreateTransaction
    {
        public record command(string Description, decimal Amount, int AccountId, TransactionType Type, int FromId) : IRequest
        {
            public record Handler(DataContext context) : IRequestHandler<command>
            {
                public async Task Handle(command request, CancellationToken cancellationToken)
                {
                    var accountExists = await context.Accounts.AnyAsync(a => a.Id == request.AccountId, cancellationToken: cancellationToken);
                    if (!accountExists)
                    {
                        throw new ArgumentException($"Account ID {request.AccountId} does not exist.");
                    }
                    var newTransaction = new Transaction
                    {
                        Description = request.Description,
                        Amount = request.Amount,
                        Type = request.Type,
                        AccountId = request.AccountId,
                        FromId = request.AccountId
                    };
                    await context.AddAsync(newTransaction);
                    await context.SaveChangesAsync();
                }
            }
        }



    }
}
