using AutoMapper;
using Transaction_System.Domain;

namespace Transaction_System.UseCases.UserUseCase.Queries.AccountQuery
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Account, GetAccount.Result>()
                .ForMember(dest => dest.ToTransactions, opt => opt.MapFrom(src => src.ToTransactions));
            CreateMap<Transaction, GetAccount.TransactionResult>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));
            CreateMap<Account, GetAccountById.Result>()
                 .ForMember(dest => dest.ToTransactions, opt => opt.MapFrom(src => src.ToTransactions));
            CreateMap<Transaction, GetAccountById.TransactionResult>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));
        }
    }
}