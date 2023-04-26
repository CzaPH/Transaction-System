using AutoMapper;
using Transaction_System.Domain;

namespace Transaction_System.UseCases.UserUseCase.Commands.Authentication
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, SignUp.signUpResult>();
            CreateMap<User, SignIn.SignInResult>();
        }
    }
}
