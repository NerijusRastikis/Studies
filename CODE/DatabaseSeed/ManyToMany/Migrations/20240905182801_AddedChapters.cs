using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManyToMany.Migrations
{
    /// <inheritdoc />
    public partial class AddedChapters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    ChapterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.ChapterId);
                    table.ForeignKey(
                        name: "FK_Chapter_!Book!_BookId",
                        column: x => x.BookId,
                        principalTable: "!Book!",
                        principalColumn: "!BookID!",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Chapter",
                columns: new[] { "ChapterId", "BookId", "Name", "Number" },
                values: new object[,]
                {
                    { 1, 0, "An Unexpected Party", 0 },
                    { 2, 0, "Roast Mutton", 0 },
                    { 3, 0, "A Short Rest", 0 },
                    { 4, 0, "Over Hill and Under Hill", 0 },
                    { 5, 0, "Riddles in the Dark", 0 },
                    { 6, 0, "A Long-expected Party", 0 },
                    { 7, 0, "The Shadow of the Past", 0 },
                    { 8, 0, "Three is Company", 0 },
                    { 9, 0, "A Knife in the Dark", 0 },
                    { 10, 0, "The Council of Elrond", 0 },
                    { 11, 0, "Ainulindal�", 0 },
                    { 12, 0, "Valaquenta", 0 },
                    { 13, 0, "Quenta Silmarillion", 0 },
                    { 14, 0, "Of Beleriand and its Realms", 0 },
                    { 15, 0, "Of the Coming of the Elves", 0 },
                    { 16, 0, "Chapter 1", 0 },
                    { 17, 0, "Chapter 2", 0 },
                    { 18, 0, "Chapter 3", 0 },
                    { 19, 0, "Chapter 4", 0 },
                    { 20, 0, "Chapter 5", 0 },
                    { 21, 0, "A Beginning", 0 },
                    { 22, 0, "Muad'Dib", 0 },
                    { 23, 0, "The Fremen", 0 },
                    { 24, 0, "Paul-Muad'Dib", 0 },
                    { 25, 0, "The Prophet", 0 },
                    { 26, 0, "The Prelude", 0 },
                    { 27, 0, "The Betrayal", 0 },
                    { 28, 0, "The Harkonnen Legacy", 0 },
                    { 29, 0, "House Corrino", 0 },
                    { 30, 0, "The Atreides Rise", 0 },
                    { 31, 0, "The Titans", 0 },
                    { 32, 0, "The Machine Crusade", 0 },
                    { 33, 0, "The Jihad Begins", 0 },
                    { 34, 0, "The Eternal War", 0 },
                    { 35, 0, "The Last Battle", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_BookId",
                table: "Chapter",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chapter");
        }
    }
}
