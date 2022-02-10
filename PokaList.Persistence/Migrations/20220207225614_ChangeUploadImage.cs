using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PokaList.Persistence.Migrations
{
    public partial class ChangeUploadImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoBytes",
                table: "AspNetUsers",
                type: "LONGBLOB",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoBytes",
                table: "AspNetUsers");
        }
    }
}
