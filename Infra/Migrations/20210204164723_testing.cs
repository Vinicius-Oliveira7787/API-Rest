using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerSheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerSheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovedStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Profile = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Score = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<double>(type: "float", maxLength: 10, nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerSheetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_AnswerSheets_AnswerSheetId",
                        column: x => x.AnswerSheetId,
                        principalTable: "AnswerSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Profile", "Score" },
                values: new object[] { new Guid("44634cf9-9604-43eb-8e88-ec5aef3ceddb"), "ademir@bol.com", "Ademir Ademilson", "0192023A7BBD73250516F069DF18B500", 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AnswerSheetId",
                table: "Answers",
                column: "AnswerSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "ApprovedStudents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AnswerSheets");
        }
    }
}
