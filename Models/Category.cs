namespace Blogs_Api_DotNet.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<BlogPost>? Posts { get; set; }
    }
}
