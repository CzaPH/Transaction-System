using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Transaction_System.Data;
using Transaction_System.Domain;
using Transaction_System.Shared.Enum;
using Transaction_System.UseCases.UserUseCase.Commands.Authentication.JwtProvider;
using static Transaction_System.UseCases.UserUseCase.Commands.Authentication.SignUp;

namespace Transaction_System.UseCases.UserUseCase.Commands.Authentication
{
    public static class SignUp
    {
        public record SignUpCommand(string Name, string Username, string Password, int Usertype) : IRequest<IEnumerable<signUpResult>>;

        public record signUpResult(string Token = "");

        public record Handler(DataContext context, IMapper mapper, IJwtProvider jwtProvider) : IRequestHandler<SignUpCommand, IEnumerable<signUpResult>>
        {
            public async Task<IEnumerable<signUpResult>> Handle(SignUpCommand command, CancellationToken cancellationToken)
            {
                var user = await context.UserCredentials.FirstOrDefaultAsync(u => u.Username == command.Username, cancellationToken);
                if (user is not null)
                {
                    throw new ArgumentException($"The username '{command.Username}' is already taken.");
                }
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(command.Password);

                var newUserCredential = new UserCredential
                {
                    Username = command.Username,
                    Password = hashedPassword
                };

                var newUser = new User
                {
                    Fullname = command.Name,
                    UserCredential = newUserCredential,
                    UserType = (UserType)command.Usertype
                   
                };

                context.Users.Add(newUser);
                await context.SaveChangesAsync();

                var signUpResult = mapper.Map<signUpResult>(newUser);

                var token = jwtProvider.GenerateToken(newUser);

                var result = new signUpResult
                {
                    Token = token
                };

                return new List<signUpResult> { result };
            }
        }

    }
}
