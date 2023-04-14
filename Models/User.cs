namespace Blogs_Api_DotNet.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Image { get; set; }
        public List<BlogPost>? Posts { get; set; }
    }
}
