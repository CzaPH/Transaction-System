using AutoMapper;
using MediatR;
using static Transaction_System.UseCases.UserUseCase.Commands.UpdateUserCredential.UpdateUserCommand;
using Transaction_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Transaction_System.UseCases.UserUseCase.Commands.UpdateUserCredentials
{
    public class DeleteUserCommand
    {
        public record Command(int Id) : IRequest
        {
            public record Handler(DataContext context, IMapper mapper) : IRequestHandler<Command>
            {
                public async Task Handle(Command request, CancellationToken cancellationToken)
                {
                    var user = await context.Users.FirstOrDefaultAsync(user => user.Id == request.Id);
                    if (user is not null)
                    {
                        user.IsDeleted = true;
                        await context.SaveChangesAsync();
                    }
                }

            }
        }
    }
}
