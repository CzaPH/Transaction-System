using AutoMapper;
using System.Transactions;
using Transaction_System.Domain;
using Transaction_System.UseCases.UserUseCase.Queries.TransactionQuery;
using Transaction = Transaction_System.Domain.Transaction;

namespace Transaction_System.UseCases.UserUseCase.Queries.TransactionQuery
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Transaction, GetTransaction.Result>();
            CreateMap<Transaction, GetTransactionById.Result>();
        }
    }

}