using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transaction_System.Data;

namespace Transaction_System.UseCases.UserUseCase.Commands.AccountCommand
{
    public static class UpdateAccount
    {
        public record command(int Id, string Name) : IRequest
        {
            public record Handler(DataContext context, IMapper mapper) : IRequestHandler<command>
            {
                public async Task Handle(command request, CancellationToken cancellationToken)
                {
                    var account = await context.Accounts.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (account is null)
                    {
                        //throw new NoUserExistException(request.Id.ToString());
                        throw new ArgumentException($"The Id '{request.Id}' is not found.");
                    }

                    account.Name = request.Name;
                    await context.SaveChangesAsync();

                }
            }
        }
    }
}

