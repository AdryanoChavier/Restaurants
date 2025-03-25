using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Infra.Migrations
{
    /// <inheritdoc />
    public partial class KiloCalories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KiloCalories",
                table: "Dishs",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KiloCalories",
                table: "Dishs");
        }
    }
}
