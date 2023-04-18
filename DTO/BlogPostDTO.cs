using System.ComponentModel.DataAnnotations;

namespace Blogs_Api_DotNet.DTO
{
    public class BlogPostDTO : IValidatableObject
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public List<int> CategoryIds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.CategoryIds != null)
            {
                if (this.CategoryIds.Count < 1)
                {
                    yield return new ValidationResult("Some required fields are missing",
                        new[] { nameof(this.CategoryIds) }
                        );
                }
            }
        }
    }
}
