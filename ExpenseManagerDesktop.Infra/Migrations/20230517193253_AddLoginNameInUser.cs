using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagerDesktop.Infra.Migrations
{
    public partial class AddLoginNameInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoginName",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginName",
                table: "Users");
        }
    }
}
