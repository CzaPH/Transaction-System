using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;
using Transaction_System.Shared.Enum;

namespace Transaction_System.UseCases.UserUseCase.Queries.AttachmentQuery
{
    public class GetAttachmentById
    {
        public record Query(int TransactionId) : IRequest<IEnumerable<Result>>;

        public record Result(int Id, string ImageUrl, int TransactionId, DateTime CreatedDate, bool IsDeleted);

        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<Query, IEnumerable<Result>>
        {
            public async Task<IEnumerable<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await context.Attachment
                    .Where(u => u.IsDeleted == false)
                    .Where(x => x.TransactionId == request.TransactionId)
                    .ToListAsync(cancellationToken);

                if (results.Count == 0)
                {
                    throw new Exception($"Attachments for TransactionId '{request.TransactionId}' do not exist.");
                }

                var mapResults = mapper.Map<IEnumerable<Result>>(results);

                return mapResults;
            }
        }
    }
}
