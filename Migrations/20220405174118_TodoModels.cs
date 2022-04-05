using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Migrations
{
    public partial class TodoModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "TodoModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoModels",
                table: "TodoModels",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoModels",
                table: "TodoModels");

            migrationBuilder.RenameTable(
                name: "TodoModels",
                newName: "Todos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "Id");
        }
    }
}
