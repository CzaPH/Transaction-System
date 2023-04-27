using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transaction_System.Migrations
{
    /// <inheritdoc />
    public partial class ModifyApprovalStatusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalStatus_Users_UserId",
                table: "ApprovalStatus");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ApprovalStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Approved",
                table: "ApprovalStatus",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalStatus_Users_UserId",
                table: "ApprovalStatus",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalStatus_Users_UserId",
                table: "ApprovalStatus");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ApprovalStatus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Approved",
                table: "ApprovalStatus",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalStatus_Users_UserId",
                table: "ApprovalStatus",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
