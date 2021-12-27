using Microsoft.EntityFrameworkCore.Migrations;

namespace PokaList.Persistence.Migrations
{
    public partial class UserIdonPokaandGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Pokas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pokas_UserId",
                table: "Pokas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_UserId",
                table: "Groups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_UserId",
                table: "Groups",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pokas_AspNetUsers_UserId",
                table: "Pokas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_UserId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokas_AspNetUsers_UserId",
                table: "Pokas");

            migrationBuilder.DropIndex(
                name: "IX_Pokas_UserId",
                table: "Pokas");

            migrationBuilder.DropIndex(
                name: "IX_Groups_UserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pokas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Groups");
        }
    }
}
