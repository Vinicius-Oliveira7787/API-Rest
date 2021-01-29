using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4438ebd6-9a78-4e2b-8962-753ca92641bf"));

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teams",
                newName: "Title");

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("5f8a0c82-4f5a-421f-a118-6f8bd7aa2abd"), "ademir@bol.com", "Ademir Ademilson", "0192023A7BBD73250516F069DF18B500", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5f8a0c82-4f5a-421f-a118-6f8bd7aa2abd"));

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Teams",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Goals",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Goals",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("4438ebd6-9a78-4e2b-8962-753ca92641bf"), "ademir@bol.com", "Ademir Ademilson", "0192023A7BBD73250516F069DF18B500", 0 });
        }
    }
}
