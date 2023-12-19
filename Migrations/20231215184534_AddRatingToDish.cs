using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arowolo_Delivery_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingToDish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Rating_DishId",
                table: "Rating",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Dishes_DishId",
                table: "Rating",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Dishes_DishId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_DishId",
                table: "Rating");
        }
    }
}
