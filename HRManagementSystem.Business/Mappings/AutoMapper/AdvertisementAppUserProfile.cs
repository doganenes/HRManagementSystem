using AutoMapper;
using HRManagementSystem.Dtos;
using HRManagementSystem.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Business.Mappings.AutoMapper
{
    public class AdvertisementAppUserProfile : Profile
    {
        public AdvertisementAppUserProfile()
        {
            CreateMap<AdvertisementAppUser,AdvertisementAppUserCreateDto>().ReverseMap();
        }

    }
}
