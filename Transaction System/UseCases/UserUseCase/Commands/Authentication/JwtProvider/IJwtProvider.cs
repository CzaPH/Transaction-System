using Transaction_System.Domain;

namespace Transaction_System.UseCases.UserUseCase.Commands.Authentication.JwtProvider
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
