using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapInfraestructura.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeTuNuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropIndex(
                name: "IX_Respuestas_PreguntaId",
                table: "Respuestas");

            migrationBuilder.DropColumn(
                name: "Opciones",
                table: "Preguntas");

            migrationBuilder.DropColumn(
                name: "RangoCalificacion",
                table: "Preguntas");

            migrationBuilder.AlterColumn<string>(
                name: "RespuestaTexto",
                table: "Respuestas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "RespuestaSeleccionada",
                table: "Respuestas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Respuestas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Preguntas",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "EscalaMax",
                table: "Preguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EscalaMin",
                table: "Preguntas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Encuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsPublica = table.Column<bool>(type: "bit", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encuestas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Encuestas_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Opcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreguntasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opcion_Preguntas_PreguntasId",
                        column: x => x.PreguntasId,
                        principalTable: "Preguntas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_PreguntaId",
                table: "Respuestas",
                column: "PreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_UsuarioIdUsuario",
                table: "Respuestas",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_EncuestaId",
                table: "Preguntas",
                column: "EncuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_UsuarioId",
                table: "Encuestas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_UsuarioIdUsuario",
                table: "Encuestas",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Opcion_PreguntasId",
                table: "Opcion",
                column: "PreguntasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Preguntas_Encuestas_EncuestaId",
                table: "Preguntas",
                column: "EncuestaId",
                principalTable: "Encuestas",
                principalColumn: "Id"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Respuestas_Usuarios_UsuarioIdUsuario",
                table: "Respuestas",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preguntas_Encuestas_EncuestaId",
                table: "Preguntas");

            migrationBuilder.DropForeignKey(
                name: "FK_Respuestas_Usuarios_UsuarioIdUsuario",
                table: "Respuestas");

            migrationBuilder.DropTable(
                name: "Encuestas");

            migrationBuilder.DropTable(
                name: "Opcion");

            migrationBuilder.DropIndex(
                name: "IX_Respuestas_PreguntaId",
                table: "Respuestas");

            migrationBuilder.DropIndex(
                name: "IX_Respuestas_UsuarioIdUsuario",
                table: "Respuestas");

            migrationBuilder.DropIndex(
                name: "IX_Preguntas_EncuestaId",
                table: "Preguntas");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Respuestas");

            migrationBuilder.DropColumn(
                name: "EscalaMax",
                table: "Preguntas");

            migrationBuilder.DropColumn(
                name: "EscalaMin",
                table: "Preguntas");

            migrationBuilder.AlterColumn<string>(
                name: "RespuestaTexto",
                table: "Respuestas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RespuestaSeleccionada",
                table: "Respuestas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Preguntas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "Opciones",
                table: "Preguntas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RangoCalificacion",
                table: "Preguntas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUltimaActividad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoCuenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuentas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_PreguntaId",
                table: "Respuestas",
                column: "PreguntaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UsuarioId",
                table: "Cuentas",
                column: "UsuarioId");
        }
    }
}
