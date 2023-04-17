using Blogs_Api_DotNet.DTO;
using FluentValidation;

namespace Blogs_Api_DotNet.Validations
{
    public class CategoryValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
