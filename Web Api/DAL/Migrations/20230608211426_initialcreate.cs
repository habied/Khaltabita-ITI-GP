using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
             name: "chef_id",
             table: "Menu_item",
             nullable: false,
             oldClrType: typeof(int),
             oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "likes",
                table: "Menu_item",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
             name: "chef_id",
             table: "Menu_item",
             nullable: true,
             oldClrType: typeof(int),
             oldNullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "likes",
                table: "Menu_item",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: false);
        }
    }

}
