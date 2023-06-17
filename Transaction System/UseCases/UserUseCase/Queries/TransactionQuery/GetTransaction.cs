
﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;
using Transaction_System.Domain;
using Transaction_System.Shared.Enum;

namespace Transaction_System.UseCases.UserUseCase.Queries.TransactionQuery
{
    public static class GetTransaction
    {
        public record Query : IRequest<IEnumerable<Result>>;

        //Get Transaction response
        public record Result(int Id, string Description, decimal Amount, TransactionType Type, int ToAccountId, int FromAccountId, DateTime CreatedDate, bool IsDeleted, ICollection<AttachmentResult> Attachments);
        public record AttachmentResult(int Id, string ImageUrl, DateTime CreatedDate, bool IsDeleted);

        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<Query, IEnumerable<Result>>
        {
            public async Task<IEnumerable<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await context.Transactions.Include(src => src.Attachments).Where(u => u.IsDeleted == false).ToListAsync(cancellationToken);
                var mapResults = mapper.Map<IEnumerable<Result>>(results);

                return mapResults;
            }
        }
    }
}
