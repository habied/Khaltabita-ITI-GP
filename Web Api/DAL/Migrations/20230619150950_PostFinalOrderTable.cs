using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class PostFinalOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Chef_ChefId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Proposal",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "proposal_id",
                table: "Cart",
                newName: "PostAcceptedOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_proposal_id",
                table: "Cart",
                newName: "IX_Cart_PostAcceptedOrderId");

            migrationBuilder.CreateTable(
                name: "PostAcceptedOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalPrice = table.Column<int>(type: "int", nullable: false),
                    QuantityUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PreparationTime_min = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    ProposalId = table.Column<int>(type: "int", nullable: false),
                    ChefId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostAcceptedOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostAcceptedOrder_Chef_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Chef",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostAcceptedOrder_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostAcceptedOrder_Proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostAcceptedOrder_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostAcceptedOrder_ChefId",
                table: "PostAcceptedOrder",
                column: "ChefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostAcceptedOrder_PostId",
                table: "PostAcceptedOrder",
                column: "PostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostAcceptedOrder_ProposalId",
                table: "PostAcceptedOrder",
                column: "ProposalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostAcceptedOrder_UserId",
                table: "PostAcceptedOrder",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Chef",
                table: "Cart",
                column: "ChefId",
                principalTable: "Chef",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_PostAcceptedOrder_PostAcceptedOrderId",
                table: "Cart",
                column: "PostAcceptedOrderId",
                principalTable: "PostAcceptedOrder",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Chef",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_PostAcceptedOrder_PostAcceptedOrderId",
                table: "Cart");

            migrationBuilder.DropTable(
                name: "PostAcceptedOrder");

            migrationBuilder.RenameColumn(
                name: "PostAcceptedOrderId",
                table: "Cart",
                newName: "proposal_id");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_PostAcceptedOrderId",
                table: "Cart",
                newName: "IX_Cart_proposal_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Chef_ChefId",
                table: "Cart",
                column: "ChefId",
                principalTable: "Chef",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Proposal",
                table: "Cart",
                column: "proposal_id",
                principalTable: "Proposal",
                principalColumn: "id");
        }
    }
}
