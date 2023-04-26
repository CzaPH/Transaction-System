using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;
using Transaction_System.Shared.Enum;

namespace Transaction_System.UseCases.UserUseCase.Queries
{
    public class GetUsers
    {
        //Get User Request
        public record Query : IRequest<IEnumerable<Result>>;

        //Get user response
        public record Result(int Id, string Fullname, string Picture, bool IsDeleted, UserType UserType);

        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<Query, IEnumerable<Result>>
        {
            public async Task<IEnumerable<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = await context.Users.Where(u => u.IsDeleted == false).ToListAsync(cancellationToken);

                var mapResults = mapper.Map<IEnumerable<Result>>(results);

                return mapResults;
            }
        }
    }
}
    
