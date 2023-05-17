using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;
using Transaction_System.Domain;
using Transaction_System.Shared.Enum;


namespace Transaction_System.UseCases.UserUseCase.Commands.TransactionCommand
{
    public static class CreateTransaction
    {
        public record Command(string Description, decimal Amount, int? AccountId, TransactionType Type, int? FromId, ICollection<string> AttachmentUrls) : IRequest;

        public record Handler(DataContext context) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var ToAccountExists = await context.Accounts.AnyAsync(a => a.Id == request.AccountId, cancellationToken: cancellationToken);
                if (!ToAccountExists && request.Type == TransactionType.Income)
                {
                    throw new ArgumentException($"To Account ID {request.AccountId} does not exist.");
                }

                var FromAccountExists = await context.Accounts.AnyAsync(a => a.Id == request.FromId, cancellationToken: cancellationToken);
                if (!FromAccountExists && request.Type == TransactionType.Expenses)
                {
                    throw new ArgumentException($"From Account ID {request.FromId} does not exist.");
                }

                var newTransaction = new Transaction
                {
                    Description = request.Description,
                    Amount = request.Amount,
                    Type = request.Type,
                    ToAccountId = request.AccountId,
                    FromAccountId = request.FromId
                };

                //Create Attachment inside the transaction.
                if (request.AttachmentUrls != null && request.AttachmentUrls.Any())
                {
                    foreach (var url in request.AttachmentUrls)
                    {
                        var attachment = new Attachment
                        {
                            ImageUrl = url,
                            Transaction = newTransaction
                        };

                        newTransaction.Attachments ??= new List<Attachment>();
                        newTransaction.Attachments.Add(attachment);
                    }
                }

                await context.AddAsync(newTransaction);
                await context.SaveChangesAsync();
            }
        }
    }
}
