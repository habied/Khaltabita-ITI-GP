using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Api.Migrations
{
    /// <inheritdoc />
    public partial class ProposalPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chef",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    media = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chef", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Menu_item",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    media = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unit_priceLE = table.Column<int>(name: "unit_price(L.E)", type: "int", nullable: false),
                    prep_timemin = table.Column<int>(name: "prep_time(min)", type: "int", nullable: true),
                    availability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    likes = table.Column<int>(type: "int", nullable: false),
                    chef_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.mobile);
                });

            migrationBuilder.CreateTable(
                name: "feedback",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    chef_id = table.Column<int>(type: "int", nullable: false),
                    review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback", x => new { x.user_id, x.chef_id });
                    table.ForeignKey(
                        name: "FK_feedback_Chef",
                        column: x => x.chef_id,
                        principalTable: "Chef",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_feedback_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "mobile");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    from_price = table.Column<int>(type: "int", nullable: true),
                    to_price = table.Column<int>(type: "int", nullable: true),
                    quantity_unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    prep_time_min = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Media = table.Column<byte[]>(type: "image", nullable: true),
                    PostState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.id);
                    table.ForeignKey(
                        name: "FK_Post_User",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "mobile");
                });

            migrationBuilder.CreateTable(
                name: "Proposal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prep_time_min = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    media = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    post_id = table.Column<int>(type: "int", nullable: false),
                    chef_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposal", x => x.id);
                    table.ForeignKey(
                        name: "FK_Proposal_Chef",
                        column: x => x.chef_id,
                        principalTable: "Chef",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Proposal_Post",
                        column: x => x.post_id,
                        principalTable: "Post",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delivery_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    total_price = table.Column<int>(type: "int", nullable: false),
                    proposal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cart_Proposal",
                        column: x => x.proposal_id,
                        principalTable: "Proposal",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Cart_User",
                        column: x => x.user_mobile,
                        principalTable: "User",
                        principalColumn: "mobile");
                });

            migrationBuilder.CreateTable(
                name: "Cart/MenuItems",
                columns: table => new
                {
                    Menu_item_id = table.Column<int>(type: "int", nullable: false),
                    Cart_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    total_item_price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart/MenuItems", x => new { x.Menu_item_id, x.Cart_id });
                    table.ForeignKey(
                        name: "FK_Cart/MenuItems_Cart",
                        column: x => x.Cart_id,
                        principalTable: "Cart",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Cart/MenuItems_Menu_item",
                        column: x => x.Menu_item_id,
                        principalTable: "Menu_item",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_proposal_id",
                table: "Cart",
                column: "proposal_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_user_mobile",
                table: "Cart",
                column: "user_mobile");

            migrationBuilder.CreateIndex(
                name: "IX_Cart/MenuItems_Cart_id",
                table: "Cart/MenuItems",
                column: "Cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_chef_id",
                table: "feedback",
                column: "chef_id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_user_id",
                table: "Post",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_chef_id",
                table: "Proposal",
                column: "chef_id");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_post_id",
                table: "Proposal",
                column: "post_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart/MenuItems");

            migrationBuilder.DropTable(
                name: "feedback");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Menu_item");

            migrationBuilder.DropTable(
                name: "Proposal");

            migrationBuilder.DropTable(
                name: "Chef");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
