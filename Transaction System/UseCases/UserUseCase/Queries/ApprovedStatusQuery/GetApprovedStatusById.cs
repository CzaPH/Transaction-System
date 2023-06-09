﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;

namespace Transaction_System.UseCases.UserUseCase.Queries.ApprovedStatusQuery
{
    public class GetApprovedStatusById
    {
        public record Query(int Id) : IRequest<IEnumerable<Result>>;

        public record Result(int Id, int UserId, int TransactionId, bool Approved, DateTime CreatedDate, bool IsDeleted);

        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<Query, IEnumerable<Result>>
        {
            public async Task<IEnumerable<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await context.ApprovalStatus
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
