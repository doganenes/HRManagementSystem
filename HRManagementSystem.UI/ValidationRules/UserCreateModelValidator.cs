using FluentValidation;
using HRManagementSystem.UI.Models;

namespace HRManagementSystem.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x => x.Password).NotEmpty().MinimumLength(3);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Password not match");
            RuleFor(x => x.Username).NotEmpty().MinimumLength(3);
            RuleFor(x => new
            {
                x.Username,
                x.FirstName
            }).Must(x => CannotFirstname(x.Username, x.FirstName)).WithMessage("Username cannot contain first name!").When(x => x.Username != null && x.FirstName != null);
            RuleFor(x => x.GenderId).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }

        private bool CannotFirstname(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}
