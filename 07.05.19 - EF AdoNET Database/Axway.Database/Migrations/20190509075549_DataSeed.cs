using Microsoft.EntityFrameworkCore.Migrations;

namespace Axway.Database.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName" },
                values: new object[] { 1, "C#" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 1, 20, "Ivan" });

            migrationBuilder.InsertData(
                table: "StudentCourse",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
