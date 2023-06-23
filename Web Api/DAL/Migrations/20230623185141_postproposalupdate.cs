using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class postproposalupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "media",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "prep_time_min",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Proposal");

            migrationBuilder.DropColumn(
                name: "media",
                table: "Post");

            migrationBuilder.AlterColumn<float>(
                name: "quantity",
                table: "Post",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "feedback",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_feedback",
                table: "feedback",
                column: "Id");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_feedback",
                table: "feedback");

            migrationBuilder.DropIndex(
                name: "IX_feedback_user_id",
                table: "feedback");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "feedback");

            migrationBuilder.AddColumn<string>(
                name: "media",
                table: "Proposal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "prep_time_min",
                table: "Proposal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Proposal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "quantity",
                table: "Post",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "media",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_feedback",
                table: "feedback",
                columns: new[] { "user_id", "chef_id" });
        }
    }
}
