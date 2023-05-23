using AutoMapper;
using Transaction_System.Domain;

namespace Transaction_System.UseCases.UserUseCase.Queries.AttachmentQuery
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Attachment, GetAttachment.Result>();
            CreateMap<Attachment, GetAttachmentById.Result>();
             
        }
    }
}
