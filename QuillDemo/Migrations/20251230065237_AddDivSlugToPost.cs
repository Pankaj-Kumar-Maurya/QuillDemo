using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuillDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddDivSlugToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "DivSlug");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DivSlug",
                table: "Posts",
                newName: "Title");
        }
    }
}
