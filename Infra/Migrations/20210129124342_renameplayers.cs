using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class renameplayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5f8a0c82-4f5a-421f-a118-6f8bd7aa2abd"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "Aswer",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("22584792-2ed7-4fb4-84b2-231a8bb5615b"), "ademir@bol.com", "Ademir Ademilson", "0192023A7BBD73250516F069DF18B500", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22584792-2ed7-4fb4-84b2-231a8bb5615b"));

            migrationBuilder.DropColumn(
                name: "Aswer",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("5f8a0c82-4f5a-421f-a118-6f8bd7aa2abd"), "ademir@bol.com", "Ademir Ademilson", "0192023A7BBD73250516F069DF18B500", 0 });
        }
    }
}
