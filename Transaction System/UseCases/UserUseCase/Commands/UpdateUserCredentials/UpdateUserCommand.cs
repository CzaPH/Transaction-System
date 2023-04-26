using AutoMapper;
using MediatR;
using Transaction_System.Data;
using Transaction_System.Shared.Enum;

using Transaction_System.UseCases.UserUseCase.Commands.Authentication.JwtProvider;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Transaction_System.UseCases.UserUseCase.Commands.UpdateUserCredential
{
    public class UpdateUserCommand
    {
        public record UpdateUserCommandData : IRequest
        {

            public int Id { get; set; }
            public string? Fullname { get; set; }
            public string? Picture { get; set; }
            public bool IsDeleted { get; set; }
            public UserType UserType { get; set; }
        };
        public record Handler(DataContext context, IMapper mapper) : IRequestHandler<UpdateUserCommandData>
        {

            public async Task Handle(UpdateUserCommandData request, CancellationToken cancellationToken)
            {
                var user = await context.Users.FirstOrDefaultAsync(user => user.Id == request.Id);
                if (user is null)
                {
                    //throw new NoUserExistException(request.Id.ToString());
                    throw new ArgumentException($"The Id '{request.Id}' is not found.");
                }

                user.Fullname = request.Fullname ?? user.Fullname;
                user.IsDeleted = request.IsDeleted;
                user.Picture = request.Picture;
                user.UserType = request.UserType;

                await context.SaveChangesAsync();
            }
        }
    }
}

