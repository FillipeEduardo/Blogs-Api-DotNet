using Blogs_Api_DotNet.DTO;
using FluentValidation;

namespace Blogs_Api_DotNet.Validations
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);
            RuleFor(x => x.DisplayName)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}
