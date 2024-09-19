using AutoMapper;
using FluentValidation;
using HRManagementSystem.Business.Extensions;
using HRManagementSystem.Business.Interfaces;
using HRManagementSystem.Business.Services.HRManagementSystem.Business.Services;
using HRManagementSystem.Common.Objects;
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
    public class AppUserService : GenericService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;

        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId)
        {

            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);
                await _unitOfWork.GetRepository<AppUser>().CreateAsync(user);
                await _unitOfWork.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleId
                });
                await _unitOfWork.SaveChanges();

                return new Response<AppUserCreateDto>(ResponseType.Success, dto);
            }

            return new Response<AppUserCreateDto>(dto, validationResult.ConvertToCustomValidationError());
        }


    }
}
