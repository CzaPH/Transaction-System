using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;

namespace Transaction_System.UseCases.UserUseCase.Queries.ApprovedStatusQuery
{
    public static class GetApprovedStatus
    {
        public record Query : IRequest<IEnumerable<Result>>;

        public record Result(int Id, int UserId, int TransactionId, bool Approved, DateTime CreatedDate, bool IsDeleted);

        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<Query, IEnumerable<Result>>
        {
            public async Task<IEnumerable<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await context.ApprovalStatus.Where(u => u.IsDeleted == false).ToListAsync(cancellationToken);
                var mapResults = mapper.Map<IEnumerable<Result>>(results);

                return mapResults;
            }
        }
    }
}
