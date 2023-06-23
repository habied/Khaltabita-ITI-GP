using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ColumnsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemUser_Menu_item_LikedMenuItemsId",
                table: "MenuItemUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemUser_User_UsersLikingItId",
                table: "MenuItemUser");

            migrationBuilder.RenameColumn(
                name: "UsersLikingItId",
                table: "MenuItemUser",
                newName: "UserLikingItId");

            migrationBuilder.RenameColumn(
                name: "LikedMenuItemsId",
                table: "MenuItemUser",
                newName: "LikedMenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemUser_UsersLikingItId",
                table: "MenuItemUser",
                newName: "IX_MenuItemUser_UserLikingItId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemUser_Menu_item_LikedMenuItemId",
                table: "MenuItemUser",
                column: "LikedMenuItemId",
                principalTable: "Menu_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemUser_User_UserLikingItId",
                table: "MenuItemUser",
                column: "UserLikingItId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemUser_Menu_item_LikedMenuItemId",
                table: "MenuItemUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemUser_User_UserLikingItId",
                table: "MenuItemUser");

            migrationBuilder.RenameColumn(
                name: "UserLikingItId",
                table: "MenuItemUser",
                newName: "UsersLikingItId");

            migrationBuilder.RenameColumn(
                name: "LikedMenuItemId",
                table: "MenuItemUser",
                newName: "LikedMenuItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemUser_UserLikingItId",
                table: "MenuItemUser",
                newName: "IX_MenuItemUser_UsersLikingItId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemUser_Menu_item_LikedMenuItemsId",
                table: "MenuItemUser",
                column: "LikedMenuItemsId",
                principalTable: "Menu_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemUser_User_UsersLikingItId",
                table: "MenuItemUser",
                column: "UsersLikingItId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
