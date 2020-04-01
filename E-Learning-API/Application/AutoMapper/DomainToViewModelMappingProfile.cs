using AutoMapper;
using E_Learning_API.Application.ViewModels;
using E_Learning_API.Models;

namespace E_Learning_API.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() {
            CreateMap<TB_EB_USER, UserForLoginViewModel>();
            CreateMap<VW_USER_Dept, UserForLoggedViewModel>();
        }
    }
}