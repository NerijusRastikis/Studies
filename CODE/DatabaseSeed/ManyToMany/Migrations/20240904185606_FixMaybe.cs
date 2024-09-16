using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManyToMany.Migrations
{
    /// <inheritdoc />
    public partial class FixMaybe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Books_BooksBookId",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Categories_CategoriesCategoryId",
                table: "BookCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "!Category!");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "!Book!");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "!Category!",
                newName: "!Genre!");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "!Category!",
                newName: "!CategoryID!");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "!Book!",
                newName: "!Year!");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "!Book!",
                newName: "!Title!");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "!Book!",
                newName: "!BookID!");

            migrationBuilder.AddPrimaryKey(
                name: "PK_!Category!",
                table: "!Category!",
                column: "!CategoryID!");

            migrationBuilder.AddPrimaryKey(
                name: "PK_!Book!",
                table: "!Book!",
                column: "!BookID!");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_!Book!_BooksBookId",
                table: "BookCategory",
                column: "BooksBookId",
                principalTable: "!Book!",
                principalColumn: "!BookID!",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_!Category!_CategoriesCategoryId",
                table: "BookCategory",
                column: "CategoriesCategoryId",
                principalTable: "!Category!",
                principalColumn: "!CategoryID!",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_!Book!_BooksBookId",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_!Category!_CategoriesCategoryId",
                table: "BookCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_!Category!",
                table: "!Category!");

            migrationBuilder.DropPrimaryKey(
                name: "PK_!Book!",
                table: "!Book!");

            migrationBuilder.RenameTable(
                name: "!Category!",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "!Book!",
                newName: "Books");

            migrationBuilder.RenameColumn(
                name: "!Genre!",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "!CategoryID!",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "!Year!",
                table: "Books",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "!Title!",
                table: "Books",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "!BookID!",
                table: "Books",
                newName: "BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookId");

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
    }
}
