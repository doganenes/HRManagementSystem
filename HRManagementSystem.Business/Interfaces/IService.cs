using HRManagementSystem.Common.Objects;
using HRManagementSystem.Dtos.Interfaces;
using HRManagementSystem.Dtos.ProvidedServiceDtos;
using HRManagementSystem.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Business.Interfaces
{
    public interface IService<CreateDto, UpdateDto, ListDto,T> where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new() where ListDto : class, IDto, new() where T: BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto
             dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto
     dto);

        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
    }
}
