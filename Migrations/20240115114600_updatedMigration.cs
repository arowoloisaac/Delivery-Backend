using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arowolo_Delivery_Project.Migrations
{
    /// <inheritdoc />
    public partial class updatedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Dishes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
