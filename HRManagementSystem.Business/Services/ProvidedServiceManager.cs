using AutoMapper;
using FluentValidation;
using HRManagementSystem.Business.Interfaces;
using HRManagementSystem.Business.Services.HRManagementSystem.Business.Services;
using HRManagementSystem.DataAccess.UnitOfWork;
using HRManagementSystem.Dtos;
using HRManagementSystem.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Business.Services
{
    public class ProvidedServiceManager : GenericService<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>, IProvidedServiceService
    {
        public ProvidedServiceManager(IMapper mapper, IValidator<ProvidedServiceCreateDto> createDtoValidator, IValidator<ProvidedServiceUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)

        {
        }
    }
}

