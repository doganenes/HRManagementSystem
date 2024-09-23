using AutoMapper;
using FluentValidation;
using HRManagementSystem.Business.Extensions;
using HRManagementSystem.Business.Interfaces;
using HRManagementSystem.Common.Enums;
using HRManagementSystem.Common.Objects;
using HRManagementSystem.DataAccess.UnitOfWork;
using HRManagementSystem.Dtos;
using HRManagementSystem.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Business.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createDtovalidator;
        private readonly IMapper _mapper;

        public AdvertisementAppUserService(IUnitOfWork unitOfWork, IValidator<AdvertisementAppUserCreateDto> createDtovalidator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _createDtovalidator = createDtovalidator;
            _mapper = mapper;
        }

        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _createDtovalidator.Validate(dto);
            if (result.IsValid)
            {
                var control = await _unitOfWork.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);

                if (control == null)
                {
                    var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _unitOfWork.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
                    await _unitOfWork.SaveChanges();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }

                List<CustomValidationError> errors = new List<CustomValidationError> {new CustomValidationError{
                    ErrorMessage  = "You have applied to the advertisement before!",
                    PropertyName = ""
                }

              };

                return new Response<AdvertisementAppUserCreateDto>(dto, errors);
            }

            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _unitOfWork.GetRepository<AdvertisementAppUser>().GetQuery();
            var list = await query.Include(x => x.Advertisement).Include(x => x.AdvertisementAppUserStatus).Include(x => x.MilitaryStatus).Include(x => x.AppUser).Where(x => x.AdvertisementAppUserStatusId == (int)type).ToListAsync();

            return _mapper.Map<List<AdvertisementAppUserListDto>>(list);
        }
    }
}
