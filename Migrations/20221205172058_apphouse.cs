using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_house.Migrations
{
    public partial class apphouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Casa",
                columns: table => new
                {
                    Casaid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dueñoname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Casaname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    imagencasa = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    metros = table.Column<int>(type: "int", nullable: false),
                    MontoF = table.Column<int>(type: "int", nullable: false),
                    eliminada = table.Column<bool>(type: "bit", nullable: false),
                    alquilada = table.Column<bool>(type: "bit", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casa", x => x.Casaid);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Clienteid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clientename = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Clienteapellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Fechanacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Clienteid);
                });

            migrationBuilder.CreateTable(
                name: "Alquiler",
                columns: table => new
                {
                    Alquilerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAlquiler = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Clienteid = table.Column<int>(type: "int", nullable: false),
                    Casaid = table.Column<int>(type: "int", nullable: false),
                    Clientename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Casaname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquiler", x => x.Alquilerid);
                    table.ForeignKey(
                        name: "FK_Alquiler_Casa_Casaid",
                        column: x => x.Casaid,
                        principalTable: "Casa",
                        principalColumn: "Casaid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquiler_Cliente_Clienteid",
                        column: x => x.Clienteid,
                        principalTable: "Cliente",
                        principalColumn: "Clienteid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devolver",
                columns: table => new
                {
                    Devolverid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alquilerid = table.Column<int>(type: "int", nullable: false),
                    Clienteid = table.Column<int>(type: "int", nullable: false),
                    Casaid = table.Column<int>(type: "int", nullable: false),
                    Clientename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Casaname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devolver", x => x.Devolverid);
                    table.ForeignKey(
                        name: "FK_Devolver_Casa_Casaid",
                        column: x => x.Casaid,
                        principalTable: "Casa",
                        principalColumn: "Casaid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devolver_Cliente_Clienteid",
                        column: x => x.Clienteid,
                        principalTable: "Cliente",
                        principalColumn: "Clienteid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_Casaid",
                table: "Alquiler",
                column: "Casaid");

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_Clienteid",
                table: "Alquiler",
                column: "Clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Devolver_Casaid",
                table: "Devolver",
                column: "Casaid");

            migrationBuilder.CreateIndex(
                name: "IX_Devolver_Clienteid",
                table: "Devolver",
                column: "Clienteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquiler");

            migrationBuilder.DropTable(
                name: "Devolver");

            migrationBuilder.DropTable(
                name: "Casa");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
