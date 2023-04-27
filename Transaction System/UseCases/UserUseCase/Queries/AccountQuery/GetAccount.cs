using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Transaction_System.Data;
using Transaction_System.Shared.Enum;
using Transaction_System.UseCases.UserUseCase.Queries.TransactionQuery;

namespace Transaction_System.UseCases.UserUseCase.Queries.AccountQuery
{
    public static class GetAccount
    {
        public record Query : IRequest<IEnumerable<Result>>;

        public record Result(int Id, string Name, DateTime CreatedDate, bool IsDeleted, ICollection<TransactionResult> ToTransactions, ICollection<TransactionResult> FromTransactions);

        public record TransactionResult(int Id, string Description, decimal Amount, TransactionType Type, DateTime CreatedDate, bool IsDeleted);

        public class Handler : IRequestHandler<Query, IEnumerable<Result>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var accounts = await _context.Accounts
                    .Include(a => a.ToTransactions)
                    .Include(a => a.FromTransactions)
                    .ToListAsync(cancellationToken);

                var results = _mapper.Map<IEnumerable<Result>>(accounts);

                return results;
            }
        }
    }
}