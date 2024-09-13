using AutoMapper;
using FluentValidation;
using HRManagementSystem.Business.Extensions;
using HRManagementSystem.Business.Interfaces;
using HRManagementSystem.Common.Objects;
using HRManagementSystem.DataAccess.UnitOfWork;
using HRManagementSystem.Dtos.Interfaces;
using HRManagementSystem.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Business.Services
{
    namespace HRManagementSystem.Business.Services
    {
        public class GenericService<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
            where CreateDto : class, IDto, new()
            where UpdateDto : class, IUpdateDto, new()
            where ListDto : class, IDto, new()
            where T : BaseEntity
        {
            private readonly IMapper _mapper;
            private readonly IValidator<CreateDto> _createDtoValidator;
            private readonly IValidator<UpdateDto> _updateDtoValidator;
            private readonly IValidator<ListDto> _listDtoValidator;
            private readonly IUnitOfWork _unitOfWork;

            public GenericService(IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator, IValidator<ListDto> listDtoValidator, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _createDtoValidator = createDtoValidator;
                _updateDtoValidator = updateDtoValidator;
                _listDtoValidator = listDtoValidator;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
            {
                var result = _createDtoValidator.Validate(dto);

                if (result.IsValid)
                {
                    var createdEntity = _mapper.Map<T>(dto);
                    await _unitOfWork.GetRepository<T>().CreateAsync(createdEntity);
                    return new Response<CreateDto>(ResponseType.Success, dto);
                }

                return new Response<CreateDto>(dto, result.ConvertToCustomValidationError());
            }

            public async Task<IResponse<List<ListDto>>> GetAllAsync()
            {
                var data = await _unitOfWork.GetRepository<T>().GetAllAsync();
                var dto = _mapper.Map<List<ListDto>>(data);
                return new Response<List<ListDto>>(ResponseType.Success, dto);
            }

            public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
            {
                var data = await _unitOfWork.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
                if (data == null)
                {
                    return new Response<IDto>(ResponseType.NotFound, $"{id}'ye sahip data bulunamadı!");
                }
                var dto = _mapper.Map<IDto>(data);
                return new Response<IDto>(ResponseType.Success, dto);
            }

            public async Task<IResponse> RemoveAsync(int id)
            {
                var data = await _unitOfWork.GetRepository<T>().FindAsync(x => x.Id == id);
                if (data == null)
                {
                    return new Response(ResponseType.NotFound, $"{id}'ye sahip data bulunamadı!");
                }
                _unitOfWork.GetRepository<T>().Remove(data);
                return new Response(ResponseType.Success);
            }

            public Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
            {
                _unitOfWork.GetRepository<T>().Update();
            }
        }
    }

}
