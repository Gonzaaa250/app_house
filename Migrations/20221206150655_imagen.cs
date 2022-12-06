using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_house.Migrations
{
    public partial class imagen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "imagencasa",
                table: "Alquiler",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagencasa",
                table: "Alquiler");
        }
    }
}
