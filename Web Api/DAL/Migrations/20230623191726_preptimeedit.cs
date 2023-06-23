using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class preptimeedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreparationTime_min",
                table: "PostAcceptedOrder");

            migrationBuilder.DropColumn(
                name: "prep_time_min",
                table: "Post");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "PostAcceptedOrder",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Post",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "PostAcceptedOrder");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Post");

            migrationBuilder.AddColumn<int>(
                name: "PreparationTime_min",
                table: "PostAcceptedOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "prep_time_min",
                table: "Post",
                type: "int",
                nullable: true);
        }
    }
}
