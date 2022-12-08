using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTeacher.Persistance.Migrations
{
    public partial class AnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Status" },
                values: new object[] { new DateTime(2022, 12, 8, 12, 34, 17, 892, DateTimeKind.Local).AddTicks(8694), 1 });

            migrationBuilder.UpdateData(
                table: "Sentences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Status" },
                values: new object[] { new DateTime(2022, 12, 8, 12, 34, 17, 892, DateTimeKind.Local).AddTicks(8697), 1 });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Status", "LastAnswer" },
                values: new object[] { new DateTime(2022, 12, 8, 12, 34, 17, 892, DateTimeKind.Local).AddTicks(8472), 1, new DateTime(2022, 12, 8, 12, 34, 17, 892, DateTimeKind.Local).AddTicks(8665) });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_WordId",
                table: "Answers",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

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
                columns: new[] { "Created", "Status" },
                values: new object[] { new DateTime(2022, 11, 24, 16, 12, 49, 33, DateTimeKind.Local).AddTicks(5769), 0 });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Status", "LastAnswer" },
                values: new object[] { new DateTime(2022, 11, 24, 16, 12, 49, 33, DateTimeKind.Local).AddTicks(5536), 0, new DateTime(2022, 11, 24, 16, 12, 49, 33, DateTimeKind.Local).AddTicks(5738) });
        }
    }
}
