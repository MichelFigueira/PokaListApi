using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PokaList.Persistence.Migrations
{
    public partial class NewFieldsinPoka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFinished",
                table: "Pokas",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "Pokas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Pokas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFinished",
                table: "Pokas");

            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Pokas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pokas");
        }
    }
}
