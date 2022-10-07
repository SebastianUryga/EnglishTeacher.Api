using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTeacher.Persistance.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sentenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Text" },
                values: new object[] { new DateTime(2022, 10, 7, 12, 12, 32, 260, DateTimeKind.Local).AddTicks(7207), "What do you do?" });

            migrationBuilder.UpdateData(
                table: "Sentenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Text" },
                values: new object[] { new DateTime(2022, 10, 7, 12, 12, 32, 260, DateTimeKind.Local).AddTicks(7217), "Just do it" });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 10, 7, 12, 12, 32, 260, DateTimeKind.Local).AddTicks(6932));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sentenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Text" },
                values: new object[] { new DateTime(2022, 9, 30, 17, 10, 47, 698, DateTimeKind.Local).AddTicks(5642), "text" });

            migrationBuilder.UpdateData(
                table: "Sentenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Text" },
                values: new object[] { new DateTime(2022, 9, 30, 17, 10, 47, 698, DateTimeKind.Local).AddTicks(5661), "text 2" });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 30, 17, 10, 47, 698, DateTimeKind.Local).AddTicks(5218));
        }
    }
}
