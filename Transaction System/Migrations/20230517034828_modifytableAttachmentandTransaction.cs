using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transaction_System.Migrations
{
    /// <inheritdoc />
    public partial class modifytableAttachmentandTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Transactions_TransactionId",
                table: "Attachment");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttachmentId1",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AttachmentId1",
                table: "Transactions",
                column: "AttachmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Transactions_TransactionId",
                table: "Attachment",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Attachment_AttachmentId1",
                table: "Transactions",
                column: "AttachmentId1",
                principalTable: "Attachment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Transactions_TransactionId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Attachment_AttachmentId1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AttachmentId1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AttachmentId1",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Transactions_TransactionId",
                table: "Attachment",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
