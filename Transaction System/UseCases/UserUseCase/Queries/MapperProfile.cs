using AutoMapper;
using Transaction_System.Domain;
using Transaction_System.UseCases.UserUseCase.Queries;

namespace Transaction_System.UseCases.UserUseCase.Commands.Authentication
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, GetUserById.Result>();
            CreateMap<User, GetUsers.Result>();
        }
    }
}
