using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Transaction_System.Data;
using Transaction_System.Shared.Enum;

namespace Transaction_System.UseCases.UserUseCase.Queries.AttachmentQuery
{
    public static class GetAttachment
    {
        public record Query : IRequest<IEnumerable<Result>>;

        public record Result(int Id, string ImageUrl, int TransactionId, DateTime CreatedDate, bool IsDeleted);

        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<Query, IEnumerable<Result>>
        {
            public async Task<IEnumerable<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await context.Attachment.Where(u => u.IsDeleted == false).ToListAsync(cancellationToken);
                var mapResults = mapper.Map<IEnumerable<Result>>(results);

                return mapResults;
            }
        }
    }
}
