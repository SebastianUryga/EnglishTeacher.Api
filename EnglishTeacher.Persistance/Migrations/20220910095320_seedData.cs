using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTeacher.Persistance.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "CorrectAnswers", "Created", "EnglishText", "Inactivated", "LastAnswer", "Modified", "PolishText", "StatusId", "WrongAnswers" },
                values: new object[] { 1, 0, new DateTime(2022, 9, 10, 11, 53, 19, 853, DateTimeKind.Local).AddTicks(8844), "Do", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "robić", 1, 0 });

            migrationBuilder.InsertData(
                table: "Sentenses",
                columns: new[] { "Id", "Created", "Inactivated", "Modified", "StatusId", "Text", "WordId" },
                values: new object[] { 1, new DateTime(2022, 9, 10, 11, 53, 19, 853, DateTimeKind.Local).AddTicks(9051), null, null, 1, "text", 1 });

            migrationBuilder.InsertData(
                table: "Sentenses",
                columns: new[] { "Id", "Created", "Inactivated", "Modified", "StatusId", "Text", "WordId" },
                values: new object[] { 2, new DateTime(2022, 9, 10, 11, 53, 19, 853, DateTimeKind.Local).AddTicks(9060), null, null, 1, "text 2", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sentenses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sentenses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
