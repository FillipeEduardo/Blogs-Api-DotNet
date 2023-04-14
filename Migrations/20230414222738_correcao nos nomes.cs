using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogs_Api_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class correcaonosnomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blog_posts_users_UserId",
                table: "blog_posts");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "users",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "users",
                newName: "display_name");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "blog_posts",
                newName: "updated");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "blog_posts",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Published",
                table: "blog_posts",
                newName: "published");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "blog_posts",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "blog_posts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "blog_posts",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_blog_posts_UserId",
                table: "blog_posts",
                newName: "IX_blog_posts_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_blog_posts_users_user_id",
                table: "blog_posts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blog_posts_users_user_id",
                table: "blog_posts");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "users",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "display_name",
                table: "users",
                newName: "DisplayName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated",
                table: "blog_posts",
                newName: "Updated");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "blog_posts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "published",
                table: "blog_posts",
                newName: "Published");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "blog_posts",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "blog_posts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "blog_posts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_blog_posts_user_id",
                table: "blog_posts",
                newName: "IX_blog_posts_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_blog_posts_users_UserId",
                table: "blog_posts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
