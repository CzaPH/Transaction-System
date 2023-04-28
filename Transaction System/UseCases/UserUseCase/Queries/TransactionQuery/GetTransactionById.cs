using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;
using Transaction_System.Shared.Enum;


namespace Transaction_System.UseCases.UserUseCase.Queries.TransactionQuery
{
    public static class GetTransactionById
    {
        public record Query(int Id) : IRequest<IEnumerable<Result>>;

        //Get user response
        public record Result(int Id, string Description, decimal Amount, TransactionType Type, int ToAccountId, int FromAccountId, DateTime CreatedDate, bool IsDeleted);

       // public record AttachmentResult(int Id, string ImageUrl, DateTime CreatedDate, bool IsDeleted);
        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<Query, IEnumerable<Result>>
        {
            public async Task<IEnumerable<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await context.Transactions
                  //  .Include(src => src.Attachments)
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