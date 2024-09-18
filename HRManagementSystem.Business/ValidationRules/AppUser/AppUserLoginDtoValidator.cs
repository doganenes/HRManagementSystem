using FluentValidation;
using HRManagementSystem.Dtos;

namespace HRManagementSystem.Business.ValidationRules.AppUser
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {   
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!");
        }
    }
}
