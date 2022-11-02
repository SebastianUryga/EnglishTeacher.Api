using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTeacher.Persistance.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolishText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnglishText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WrongAnswers = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CorrectAnswers = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastAnswer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sentences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sentenses_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "Created", "CreatedBy", "EnglishText", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "PolishText", "StatusId", "LastAnswer" },
                values: new object[] { 1, new DateTime(2022, 11, 1, 13, 10, 4, 805, DateTimeKind.Local).AddTicks(5606), "Admin", "Do", null, null, null, null, "robić", 1, new DateTime(2022, 11, 1, 13, 10, 4, 805, DateTimeKind.Local).AddTicks(5766) });

            migrationBuilder.InsertData(
                table: "Sentences",
                columns: new[] { "Id", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId", "Text", "WordId" },
                values: new object[] { 1, new DateTime(2022, 11, 1, 13, 10, 4, 805, DateTimeKind.Local).AddTicks(5811), "Admin", null, null, null, null, 1, "What do you do?", 1 });

            migrationBuilder.InsertData(
                table: "Sentences",
                columns: new[] { "Id", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId", "Text", "WordId" },
                values: new object[] { 2, new DateTime(2022, 11, 1, 13, 10, 4, 805, DateTimeKind.Local).AddTicks(5813), "Adnim", null, null, null, null, 1, "Just do it", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Sentenses_WordId",
                table: "Sentences",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sentences");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
