using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_PO.Migrations
{
    /// <inheritdoc />
    public partial class Kurs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Kursy_KursId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Kursy_KursId",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kursy",
                table: "Kursy");

            migrationBuilder.RenameTable(
                name: "Kursy",
                newName: "Kurs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kurs",
                table: "Kurs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Kurs_KursId",
                table: "Comments",
                column: "KursId",
                principalTable: "Kurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Kurs_KursId",
                table: "Feedbacks",
                column: "KursId",
                principalTable: "Kurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Kurs_KursId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Kurs_KursId",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kurs",
                table: "Kurs");

            migrationBuilder.RenameTable(
                name: "Kurs",
                newName: "Kursy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kursy",
                table: "Kursy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Kursy_KursId",
                table: "Comments",
                column: "KursId",
                principalTable: "Kursy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Kursy_KursId",
                table: "Feedbacks",
                column: "KursId",
                principalTable: "Kursy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
