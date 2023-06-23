using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItemUser",
                columns: table => new
                {
                    LikedMenuItemsId = table.Column<int>(type: "int", nullable: false),
                    UsersLikingItId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemUser", x => new { x.LikedMenuItemsId, x.UsersLikingItId });
                    table.ForeignKey(
                        name: "FK_MenuItemUser_Menu_item_LikedMenuItemsId",
                        column: x => x.LikedMenuItemsId,
                        principalTable: "Menu_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemUser_User_UsersLikingItId",
                        column: x => x.UsersLikingItId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemUser_UsersLikingItId",
                table: "MenuItemUser",
                column: "UsersLikingItId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItemUser");

        }
    }
}
