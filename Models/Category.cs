using System.Text.Json.Serialization;

namespace Blogs_Api_DotNet.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public List<BlogPost>? Posts { get; set; }
    }
}
