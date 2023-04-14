using Blogs_Api_DotNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs_Api_DotNet.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder
                .HasKey(x => x.Id)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder
                .Property(x => x.DisplayName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("display_name");
            builder
                .Property(x => x.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            builder
                .Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("password");
            builder
                .Property(x => x.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
        }
    }
}