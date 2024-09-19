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
        private readonly IValidator<AppUserLoginDto> _loginDtoValidator;

        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUnitOfWork unitOfWork, IValidator<AppUserLoginDto> loginDtoValidator) : base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
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

        public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
        {
            var validationResult = _loginDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = await _unitOfWork.GetRepository<AppUser>().GetByFilterAsync(x => x.Username == dto.UserName && x.Password == dto.Password);

                if (user != null)
                {
                    var appUserDto = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Success, appUserDto);
                }

                return new Response<AppUserListDto>(ResponseType.NotFound, "Username or password is incorrect!");
            }

            return new Response<AppUserListDto>(ResponseType.ValidationError, "Username or password cannot be empty!");
        }

        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId)
        {
            var roles = await _unitOfWork.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if (roles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "İlgili rol bulunamadı!");
            }

            var dto = _mapper.Map<List<AppRoleListDto>>(roles);

            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);
        }
    }
}
