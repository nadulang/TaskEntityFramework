using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskEntityFramework.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactUsers",
                table: "ContactUsers");

            migrationBuilder.RenameTable(
                name: "ContactUsers",
                newName: "UserContacts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserContacts",
                table: "UserContacts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserContacts",
                table: "UserContacts");

            migrationBuilder.RenameTable(
                name: "UserContacts",
                newName: "ContactUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactUsers",
                table: "ContactUsers",
                column: "Id");
        }
    }
}
