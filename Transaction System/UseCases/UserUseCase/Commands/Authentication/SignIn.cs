using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;
using Transaction_System.Data;
using Transaction_System.UseCases.UserUseCase.Commands.Authentication.JwtProvider;

namespace Transaction_System.UseCases.UserUseCase.Commands.Authentication
{
    public static class SignIn
    {
        public record SignInCommand(string Username, string Password) : IRequest<IEnumerable<SignInResult>>;

        public record SignInResult(string Token = "");

        public record SignInResponse(string Token);

        public record Handler(DataContext context, IMapper mapper, IJwtProvider jwtProvider) : IRequestHandler<SignInCommand, IEnumerable<SignInResult>>
        {
            public async Task<IEnumerable<SignInResult>> Handle(SignInCommand command, CancellationToken cancellationToken)
            {
                var userCredential = await context.UserCredentials.FirstOrDefaultAsync(x => x.Username == command.Username, cancellationToken);

                if (userCredential == null || !BCrypt.Net.BCrypt.Verify(command.Password, userCredential.Password))
                {
                    throw new AuthenticationException("Invalid username or password");
                }

                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userCredential.Id, cancellationToken);

                if (user == null)
                {
                    throw new AuthenticationException("User not found");
                }

                var token = jwtProvider.GenerateToken(user!);
                var result = new SignInResult(token);
                return new List<SignInResult> { result };
                // var signInResult = mapper.Map<SignInResult>(user);

                // return new List<SignInResult> { signInResult };
            }
        }
    }
}
