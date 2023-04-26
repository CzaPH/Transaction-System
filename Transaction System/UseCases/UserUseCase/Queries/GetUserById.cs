using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;

namespace Transaction_System.UseCases.UserUseCase.Queries
{
    public static class GetUserById
    {
        //Get User Request
        public record Query(int Id) : IRequest<IEnumerable<Result>>;

        //Get user response
        public record Result(int id, string Fullname);

        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<Query, IEnumerable<Result>>
        {
            public async Task<IEnumerable<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await context.Users
                    .Where(x => x.Id == request.Id)
                    .ToListAsync(cancellationToken);
                if (result is null) throw new Exception("User does not exist.");

                var mapResult = mapper.Map<IEnumerable<Result>>(result);

                return mapResult;
            }
        }

    }
}
