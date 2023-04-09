using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatGpt.Infrastructure.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Chat_ContextCount",
                table: "chatgptsetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Chat_EnableContext",
                table: "chatgptsetting",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chat_ContextCount",
                table: "chatgptsetting");

            migrationBuilder.DropColumn(
                name: "Chat_EnableContext",
                table: "chatgptsetting");
        }
    }
}
