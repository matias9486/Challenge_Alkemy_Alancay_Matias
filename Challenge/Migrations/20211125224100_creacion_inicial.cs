using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge.Migrations
{
    public partial class creacion_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Personajes",
                columns: table => new
                {
                    PersonajeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personajes", x => x.PersonajeId);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas_Series",
                columns: table => new
                {
                    Pelicula_SerieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Creación = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Caliﬁcacion = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas_Series", x => x.Pelicula_SerieId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Series_generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula_SeriePersonaje",
                columns: table => new
                {
                    Peliculas_SeriesPelicula_SerieId = table.Column<int>(type: "int", nullable: false),
                    Personajes_AsociadosPersonajeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula_SeriePersonaje", x => new { x.Peliculas_SeriesPelicula_SerieId, x.Personajes_AsociadosPersonajeId });
                    table.ForeignKey(
                        name: "FK_Pelicula_SeriePersonaje_Peliculas_Series_Peliculas_SeriesPelicula_SerieId",
                        column: x => x.Peliculas_SeriesPelicula_SerieId,
                        principalTable: "Peliculas_Series",
                        principalColumn: "Pelicula_SerieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pelicula_SeriePersonaje_Personajes_Personajes_AsociadosPersonajeId",
                        column: x => x.Personajes_AsociadosPersonajeId,
                        principalTable: "Personajes",
                        principalColumn: "PersonajeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_SeriePersonaje_Personajes_AsociadosPersonajeId",
                table: "Pelicula_SeriePersonaje",
                column: "Personajes_AsociadosPersonajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_Series_GeneroId",
                table: "Peliculas_Series",
                column: "GeneroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pelicula_SeriePersonaje");

            migrationBuilder.DropTable(
                name: "Peliculas_Series");

            migrationBuilder.DropTable(
                name: "Personajes");

            migrationBuilder.DropTable(
                name: "generos");
        }
    }
}
