using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManyToMany.Migrations
{
    /// <inheritdoc />
    public partial class EditedModelBuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Books_BookId",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Categories_CategoryId",
                table: "BookCategory");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BookCategory",
                newName: "CategoriesCategoryId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookCategory",
                newName: "BooksBookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoriesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Books_BooksBookId",
                table: "BookCategory",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Categories_CategoriesCategoryId",
                table: "BookCategory",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Books_BooksBookId",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Categories_CategoriesCategoryId",
                table: "BookCategory");

            migrationBuilder.RenameColumn(
                name: "CategoriesCategoryId",
                table: "BookCategory",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "BooksBookId",
                table: "BookCategory",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoriesCategoryId",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Books_BookId",
                table: "BookCategory",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Categories_CategoryId",
                table: "BookCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
