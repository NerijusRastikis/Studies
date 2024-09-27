using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentuInformacineSistema.Migrations
{
    /// <inheritdoc />
    public partial class Initial_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentCode);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    LectureName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LectureTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.LectureName);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentNumber);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "DepartmentCode");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLectures",
                columns: table => new
                {
                    DepartmentsDepartmentCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LecturesLectureName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLectures", x => new { x.DepartmentsDepartmentCode, x.LecturesLectureName });
                    table.ForeignKey(
                        name: "FK_DepartmentLectures_Departments_DepartmentsDepartmentCode",
                        column: x => x.DepartmentsDepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "DepartmentCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentLectures_Lectures_LecturesLectureName",
                        column: x => x.LecturesLectureName,
                        principalTable: "Lectures",
                        principalColumn: "LectureName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentLectures",
                columns: table => new
                {
                    LecturesLectureName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentsStudentNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLectures", x => new { x.LecturesLectureName, x.StudentsStudentNumber });
                    table.ForeignKey(
                        name: "FK_StudentLectures_Lectures_LecturesLectureName",
                        column: x => x.LecturesLectureName,
                        principalTable: "Lectures",
                        principalColumn: "LectureName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLectures_Students_StudentsStudentNumber",
                        column: x => x.StudentsStudentNumber,
                        principalTable: "Students",
                        principalColumn: "StudentNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentCode", "DepartmentName" },
                values: new object[,]
                {
                    { "CS1234", "ComputerScience" },
                    { "MTH567", "Mathematics" }
                });

            migrationBuilder.InsertData(
                table: "Lectures",
                columns: new[] { "LectureName", "LectureTime" },
                values: new object[,]
                {
                    { "Algorithms", "10:00-11:30" },
                    { "Calculus", "12:00-13:30" },
                    { "DataStructures", "14:00-15:30" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentLectures",
                columns: new[] { "DepartmentsDepartmentCode", "LecturesLectureName" },
                values: new object[,]
                {
                    { "CS1234", "Algorithms" },
                    { "CS1234", "DataStructures" },
                    { "MTH567", "Calculus" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentNumber", "DepartmentCode", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 12345678, "CS1234", "john.smith@example.com", "John", "Smith" },
                    { 87654321, "MTH567", "alice.johnson@example.com", "Alice", "Johnson" }
                });

            migrationBuilder.InsertData(
                table: "StudentLectures",
                columns: new[] { "LecturesLectureName", "StudentsStudentNumber" },
                values: new object[,]
                {
                    { "Algorithms", 12345678 },
                    { "Calculus", 87654321 },
                    { "DataStructures", 12345678 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLectures_LecturesLectureName",
                table: "DepartmentLectures",
                column: "LecturesLectureName");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLectures_StudentsStudentNumber",
                table: "StudentLectures",
                column: "StudentsStudentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentCode",
                table: "Students",
                column: "DepartmentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentLectures");

            migrationBuilder.DropTable(
                name: "StudentLectures");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
