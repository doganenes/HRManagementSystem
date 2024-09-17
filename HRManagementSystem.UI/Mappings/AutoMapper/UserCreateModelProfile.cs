using AutoMapper;
using HRManagementSystem.Dtos;
using HRManagementSystem.UI.Models;

namespace HRManagementSystem.UI.Mappings.AutoMapper
{
    public class UserCreateModelProfile : Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>().ReverseMap();
        }
    }
}
