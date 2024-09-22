using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIS.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentCode);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    LectureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LectureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectureStartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    LectureEndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.LectureId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentNumber = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentNumber);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "DepartmentCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLecture",
                columns: table => new
                {
                    DepartmentCode = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    LectureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLecture", x => new { x.DepartmentCode, x.LectureId });
                    table.ForeignKey(
                        name: "FK_DepartmentLecture_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "DepartmentCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentLecture_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "LectureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LectureStudent",
                columns: table => new
                {
                    LectureId = table.Column<int>(type: "int", nullable: false),
                    StudentNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureStudent", x => new { x.LectureId, x.StudentNumber });
                    table.ForeignKey(
                        name: "FK_LectureStudent_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "LectureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureStudent_Students_StudentNumber",
                        column: x => x.StudentNumber,
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
                columns: new[] { "LectureId", "DayOfWeek", "LectureEndTime", "LectureName", "LectureStartTime" },
                values: new object[,]
                {
                    { -3, "Wednesday", new TimeSpan(0, 15, 30, 0, 0), "DataStructures", new TimeSpan(0, 14, 0, 0, 0) },
                    { -2, "Tuesday", new TimeSpan(0, 13, 30, 0, 0), "Calculus", new TimeSpan(0, 12, 0, 0, 0) },
                    { -1, "Monday", new TimeSpan(0, 11, 30, 0, 0), "Algorithms", new TimeSpan(0, 10, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "DepartmentLecture",
                columns: new[] { "DepartmentCode", "LectureId" },
                values: new object[,]
                {
                    { "CS1234", -3 },
                    { "CS1234", -1 },
                    { "MTH567", -2 }
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
                table: "LectureStudent",
                columns: new[] { "LectureId", "StudentNumber" },
                values: new object[,]
                {
                    { -3, 12345678 },
                    { -2, 87654321 },
                    { -1, 12345678 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLecture_LectureId",
                table: "DepartmentLecture",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureStudent_StudentNumber",
                table: "LectureStudent",
                column: "StudentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentCode",
                table: "Students",
                column: "DepartmentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentLecture");

            migrationBuilder.DropTable(
                name: "LectureStudent");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
