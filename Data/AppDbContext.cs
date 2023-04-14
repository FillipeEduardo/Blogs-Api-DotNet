using Microsoft.EntityFrameworkCore;

namespace Blogs_Api_DotNet.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<> MyProperty { get; set; }
    }
}
