using AutoMapper;
using Transaction_System.Domain;

namespace Transaction_System.UseCases.UserUseCase.Queries.TransactionQuery
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Transaction, GetTransaction.Result>();
            CreateMap<Transaction, GetTransactionById.Result>();
            CreateMap<Attachment, GetTransactionById.AttachmentResult>(); // Add this mapping
            CreateMap<Attachment, GetTransaction.AttachmentResult>(); // Add this mapping if you want to include transaction
        }
    }


}

