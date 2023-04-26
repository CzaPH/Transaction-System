using AutoMapper;
using Transaction_System.Domain;

namespace Transaction_System.UseCases.UserUseCase.Queries.AccountQuery
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Account, GetAccount.Result>();
            CreateMap<Account, GetAccountById.Result>();


        }
    }
}
