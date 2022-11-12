using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDVillanosApp.Migrations
{
    /// <inheritdoc />
    public partial class Indimin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "dia",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dia",
                table: "Tarea");
        }
    }
}
