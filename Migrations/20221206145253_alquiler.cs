using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_house.Migrations
{
    public partial class alquiler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MontoTotal",
                table: "Alquiler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoTotal",
                table: "Alquiler");
        }
    }
}
