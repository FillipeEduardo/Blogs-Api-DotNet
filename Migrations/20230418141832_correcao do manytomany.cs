using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogs_Api_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class correcaodomanytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_categories_blog_posts_category_id",
                table: "posts_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_categories_categories_post_id",
                table: "posts_categories");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_categories_blog_posts_post_id",
                table: "posts_categories",
                column: "post_id",
                principalTable: "blog_posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_categories_categories_category_id",
                table: "posts_categories",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_categories_blog_posts_post_id",
                table: "posts_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_categories_categories_category_id",
                table: "posts_categories");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_categories_blog_posts_category_id",
                table: "posts_categories",
                column: "category_id",
                principalTable: "blog_posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_categories_categories_post_id",
                table: "posts_categories",
                column: "post_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
