using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Migrations
{
    public partial class CorretionTodoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TodoModels");

            migrationBuilder.RenameColumn(
                name: "Tite",
                table: "TodoModels",
                newName: "Title");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TodoModels",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TodoModels",
                newName: "Tite");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TodoModels",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TodoModels",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
