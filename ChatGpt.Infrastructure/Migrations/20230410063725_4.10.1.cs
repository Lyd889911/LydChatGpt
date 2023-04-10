using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatGpt.Infrastructure.Migrations
{
    public partial class _4101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chatgptsetting_user_UserId",
                table: "chatgptsetting");

            migrationBuilder.DropIndex(
                name: "IX_chatgptsetting_UserId",
                table: "chatgptsetting");

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteCreatorId",
                table: "chatgptsetting",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "chatgptsetting",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "chatgptsetting",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteCreatorId",
                table: "chatgptsetting");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "chatgptsetting");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "chatgptsetting");

            migrationBuilder.CreateIndex(
                name: "IX_chatgptsetting_UserId",
                table: "chatgptsetting",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_chatgptsetting_user_UserId",
                table: "chatgptsetting",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
