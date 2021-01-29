using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Answer_AnswerId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_AnswerSheetId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa43d63e-0b06-4490-b884-29e8cbda7043"));

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "AnswerSheets");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Answer",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_Players_AnswerSheetId",
                table: "Questions",
                newName: "IX_Questions_AnswerSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_AnswerId",
                table: "Questions",
                newName: "IX_Questions_AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerSheets",
                table: "AnswerSheets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("ceb996ae-6f10-445e-9062-a834b9ad47a1"), "ademir@bol.com", "Ademir Ademilson", "0192023A7BBD73250516F069DF18B500", 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Answers_AnswerId",
                table: "Questions",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AnswerSheets_AnswerSheetId",
                table: "Questions",
                column: "AnswerSheetId",
                principalTable: "AnswerSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Answers_AnswerId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AnswerSheets_AnswerSheetId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerSheets",
                table: "AnswerSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ceb996ae-6f10-445e-9062-a834b9ad47a1"));

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "AnswerSheets",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Answer");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_AnswerSheetId",
                table: "Players",
                newName: "IX_Players_AnswerSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_AnswerId",
                table: "Players",
                newName: "IX_Players_AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("aa43d63e-0b06-4490-b884-29e8cbda7043"), "ademir@bol.com", "Ademir Ademilson", "0192023A7BBD73250516F069DF18B500", 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Answer_AnswerId",
                table: "Players",
                column: "AnswerId",
                principalTable: "Answer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_AnswerSheetId",
                table: "Players",
                column: "AnswerSheetId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
