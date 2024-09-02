using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acceso_Datos.Migrations
{
    public partial class Migracion_DeInicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    IdCiudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.IdCiudad);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    IdProfesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Aula = table.Column<int>(type: "int", nullable: false),
                    Fotografia = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IdCiudadEnPersona = table.Column<int>(type: "int", nullable: false),
                    IdRolEnPersona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.IdProfesor);
                    table.ForeignKey(
                        name: "FK_Profesores_Ciudades_IdCiudadEnPersona",
                        column: x => x.IdCiudadEnPersona,
                        principalTable: "Ciudades",
                        principalColumn: "IdCiudad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profesores_Roles_IdRolEnPersona",
                        column: x => x.IdRolEnPersona,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    IdMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IdProfesorEnMateria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.IdMateria);
                    table.ForeignKey(
                        name: "FK_Materias_Profesores_IdProfesorEnMateria",
                        column: x => x.IdProfesorEnMateria,
                        principalTable: "Profesores",
                        principalColumn: "IdProfesor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fotografia = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IdMateriaEnEstudiante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IdEstudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Materias_IdMateriaEnEstudiante",
                        column: x => x.IdMateriaEnEstudiante,
                        principalTable: "Materias",
                        principalColumn: "IdMateria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_IdMateriaEnEstudiante",
                table: "Estudiantes",
                column: "IdMateriaEnEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_IdProfesorEnMateria",
                table: "Materias",
                column: "IdProfesorEnMateria");

            migrationBuilder.CreateIndex(
                name: "IX_Profesores_IdCiudadEnPersona",
                table: "Profesores",
                column: "IdCiudadEnPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Profesores_IdRolEnPersona",
                table: "Profesores",
                column: "IdRolEnPersona");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
