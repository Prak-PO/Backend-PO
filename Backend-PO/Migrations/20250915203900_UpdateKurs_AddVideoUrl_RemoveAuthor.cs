using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_PO.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKurs_AddVideoUrl_RemoveAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kursy_Users_AuthorId",
                table: "Kursy");

            migrationBuilder.DropIndex(
                name: "IX_Kursy_AuthorId",
                table: "Kursy");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Kursy");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Kursy",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Kursy");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Kursy",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Kursy_AuthorId",
                table: "Kursy",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kursy_Users_AuthorId",
                table: "Kursy",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
