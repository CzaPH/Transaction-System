using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;
using Transaction_System.Shared.Enum;
using static Transaction_System.UseCases.UserUseCase.Queries.AccountQuery.GetAccount;

namespace Transaction_System.UseCases.UserUseCase.Queries.AccountQuery
{
    public static class GetAccountById
    {
        public record Query(int Id) : IRequest<IEnumerable<Result>>;

        //Get user response
        public record Result(int Id, string Name, DateTime CreatedDate, bool IsDeleted, ICollection<TransactionResult> ToTransactions, ICollection<TransactionResult> FromTransactions);
        public record TransactionResult(int Id, string Description, decimal Amount, TransactionType Type, DateTime CreatedDate, bool IsDeleted);

        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<Query, IEnumerable<Result>>
        {
            public async Task<IEnumerable<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await context.Accounts.Include(a => a.ToTransactions)
                    .Where(x => x.Id == request.Id)
                    .ToListAsync(cancellationToken);
                if (result is null || !result.Any())
                {
                    throw new Exception($"Id '{request.Id}' is not existing.");
                }
                var mapResult = mapper.Map<IEnumerable<Result>>(result);

                return mapResult;
            }
        }
    }
}
