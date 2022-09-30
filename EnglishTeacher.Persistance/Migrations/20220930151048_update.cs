using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishTeacher.Persistance.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Words",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InactivatedBy",
                table: "Words",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Words",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Sentenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InactivatedBy",
                table: "Sentenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Sentenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Sentenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "CreatedBy" },
                values: new object[] { new DateTime(2022, 9, 30, 17, 10, 47, 698, DateTimeKind.Local).AddTicks(5642), "Admin" });

            migrationBuilder.UpdateData(
                table: "Sentenses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "CreatedBy" },
                values: new object[] { new DateTime(2022, 9, 30, 17, 10, 47, 698, DateTimeKind.Local).AddTicks(5661), "Adnim" });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "CreatedBy" },
                values: new object[] { new DateTime(2022, 9, 30, 17, 10, 47, 698, DateTimeKind.Local).AddTicks(5218), "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "InactivatedBy",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Sentenses");

            migrationBuilder.DropColumn(
                name: "InactivatedBy",
                table: "Sentenses");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Sentenses");

            migrationBuilder.UpdateData(
                table: "Sentenses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 22, 13, 23, 16, 417, DateTimeKind.Local).AddTicks(7169));

            migrationBuilder.UpdateData(
                table: "Sentenses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 22, 13, 23, 16, 417, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 22, 13, 23, 16, 417, DateTimeKind.Local).AddTicks(6925));
        }
    }
}
