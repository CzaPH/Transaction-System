using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Transaction_System.Data;
using Transaction_System.Shared.Enum;

namespace Transaction_System.UseCases.UserUseCase.Queries.AccountQuery
{
    public static class GetAccount
    {
        public record Query : IRequest<IEnumerable<Result>>;


        public record Result(int Id, string Name, DateTime CreatedDate, bool IsDeleted, ICollection<Result> Transactions);

        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<Query, IEnumerable<Result>>
        {
            public async Task<IEnumerable<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await context.Accounts.Include(x => x.Transactions).Where(u => u.IsDeleted == false).ToListAsync(cancellationToken);

                var mapResults = mapper.Map<IEnumerable<Result>>(results);

                return mapResults;
            }
        }
    }
}

