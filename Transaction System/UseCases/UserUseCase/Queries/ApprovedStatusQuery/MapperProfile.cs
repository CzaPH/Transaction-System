using AutoMapper;
using Transaction_System.Domain;


namespace Transaction_System.UseCases.UserUseCase.Queries.ApprovedStatusQuery
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ApprovalStatus, GetApprovedStatus.Result>();
            CreateMap<ApprovalStatus, GetApprovedStatusById.Result>();

        }
    
    }
}
