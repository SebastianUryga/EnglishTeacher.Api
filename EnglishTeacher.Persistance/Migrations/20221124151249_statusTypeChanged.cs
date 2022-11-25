using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTeacher.Persistance.Migrations
{
    public partial class statusTypeChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Words",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Sentences",
                newName: "Status");

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Status" },
                values: new object[] { new DateTime(2022, 11, 24, 16, 12, 49, 33, DateTimeKind.Local).AddTicks(5765), 0 });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "CreatedBy", "Status" },
                values: new object[] { new DateTime(2022, 11, 24, 16, 12, 49, 33, DateTimeKind.Local).AddTicks(5769), "Admin", 0 });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Status", "LastAnswer" },
                values: new object[] { new DateTime(2022, 11, 24, 16, 12, 49, 33, DateTimeKind.Local).AddTicks(5536), 0, new DateTime(2022, 11, 24, 16, 12, 49, 33, DateTimeKind.Local).AddTicks(5738) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Words",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Sentences",
                newName: "StatusId");

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "StatusId" },
                values: new object[] { new DateTime(2022, 11, 8, 16, 4, 36, 827, DateTimeKind.Local).AddTicks(9529), 1 });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "CreatedBy", "StatusId" },
                values: new object[] { new DateTime(2022, 11, 8, 16, 4, 36, 827, DateTimeKind.Local).AddTicks(9531), "Adnim", 1 });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "StatusId", "LastAnswer" },
                values: new object[] { new DateTime(2022, 11, 8, 16, 4, 36, 827, DateTimeKind.Local).AddTicks(9282), 1, new DateTime(2022, 11, 8, 16, 4, 36, 827, DateTimeKind.Local).AddTicks(9492) });
        }
    }
}
