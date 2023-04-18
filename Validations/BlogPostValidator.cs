using Blogs_Api_DotNet.DTO;
using FluentValidation;

namespace Blogs_Api_DotNet.Validations
{
    public class BlogPostValidator : AbstractValidator<BlogPostDTO>
    {
        public BlogPostValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleForEach(x => x.CategoryIds).NotNull().NotEmpty();
        }
    }
}
