using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;

namespace Transaction_System.UseCases.UserUseCase.Commands.TransactionCommand
{
    public static class RemoveTransaction
    {
        public record command(int Id) : IRequest
        {
            public record Handler(DataContext context, IMapper mapper) : IRequestHandler<command>
            {
                public async Task Handle(command request, CancellationToken cancellationToken)
                {
                    var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (transaction is not null)
                    {
                        transaction.IsDeleted = true;
                        await context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
