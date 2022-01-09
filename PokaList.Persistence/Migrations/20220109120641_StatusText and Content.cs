using Microsoft.EntityFrameworkCore.Migrations;

namespace PokaList.Persistence.Migrations
{
    public partial class StatusTextandContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusText",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusText",
                table: "AspNetUsers");
        }
    }
}
