using Blogs_Api_DotNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs_Api_DotNet.Data.Mappings
{
    public class BlogPostMap : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.ToTable("blog_posts");

            builder.HasKey(x => x.Id)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("title");

            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("content");

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("user_id");

            builder.Property(x => x.Published)
                .HasColumnName("published");

            builder.Property(x => x.Updated)
                .HasColumnName("updated");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Categories)
                .WithMany(x => x.Posts)
                .UsingEntity<Dictionary<string, object>>(
                "posts_categories",
                post => post.HasOne<Category>()
                .WithMany()
                .HasForeignKey("post_id")
                .OnDelete(DeleteBehavior.Cascade),
                category => category.HasOne<BlogPost>()
                .WithMany()
                .HasForeignKey("category_id")
                .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}
