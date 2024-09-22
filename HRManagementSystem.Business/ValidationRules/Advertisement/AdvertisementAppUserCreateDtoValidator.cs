using FluentValidation;
using HRManagementSystem.Common.Enums;
using HRManagementSystem.Dtos;

namespace HRManagementSystem.Business.ValidationRules.Advertisement
{
    public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            RuleFor(x => x.AdvertisementAppUserStatusId).NotEmpty();
            RuleFor(x => x.AdvertisementId).NotEmpty();
            RuleFor(x => x.AppUserId).NotEmpty();
            RuleFor(x => x.CvPath).NotEmpty().WithMessage("Upload your cv file!");
            RuleFor(x => x.EndDate).NotEmpty().When(x => x.MilitaryStatusId == (int)MilitaryStatusType.Postponed).WithMessage("End date can not be empty!");    
        }
    }
}
