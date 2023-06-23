using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddChefIdToCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChefId",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: true,
                defaultValue: "");
            migrationBuilder.CreateIndex(
                name: "IX_Cart_ChefId",
                table: "Cart",
                column: "ChefId");
            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Chef_ChefId",
                table: "Cart",
                column: "ChefId",
                principalTable: "Chef",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Chef_ChefId",
                table: "Cart");
            migrationBuilder.DropIndex(
                name: "IX_Cart_ChefId",
                table: "Cart");
            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "Cart");
        }
    }
}
