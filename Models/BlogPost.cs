namespace Blogs_Api_DotNet.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime? Published { get; set; }
        public DateTime? Updated { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
