using MediatR;
using Transaction_System.Data;

namespace Transaction_System.UseCases.UserUseCase.Commands.AccountCommand
{
    public static class CreateAccount
    {
        public record Command(string Name) : IRequest
        {
            public record Handler(DataContext context) : IRequestHandler<Command>
            {
                public async Task Handle(Command request, CancellationToken cancellationToken)
                {
                    var newAccount = new Domain.Account
                    {
                        Name = request.Name
                    };
                    await context.AddAsync(newAccount);
                    await context.SaveChangesAsync();
                }
            }
        }

    }
}
