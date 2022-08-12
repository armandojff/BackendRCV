using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taller.Persistence.Migrations
{
    public partial class bdTaller3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Analisis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_usuario_taller = table.Column<Guid>(type: "uuid", nullable: false),
                    cotizacion_taller = table.Column<Guid>(type: "uuid", nullable: true),
                    titulo_analisis = table.Column<string>(type: "text", nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analisis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca_carro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre_marca = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca_carro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    nombre_taller = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    direccion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    cumplimiento = table.Column<int>(type: "integer", nullable: false),
                    RIF = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orden_compra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    limite_dias_pago = table.Column<int>(type: "integer", nullable: false),
                    fecha_vencimiento = table.Column<DateTime>(type: "DATE", nullable: false),
                    total_pagar = table.Column<double>(type: "double precision", nullable: false),
                    descripcion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    factura = table.Column<string>(type: "text", nullable: true),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    analisisId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden_compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orden_compra_Analisis_analisisId",
                        column: x => x.analisisId,
                        principalTable: "Analisis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Piezas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    descripcion_pieza = table.Column<string>(type: "text", nullable: false),
                    id_marcca_pieza = table.Column<Guid>(type: "uuid", nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    precio = table.Column<double>(type: "double precision", nullable: true),
                    analisisId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piezas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Piezas_Analisis_analisisId",
                        column: x => x.analisisId,
                        principalTable: "Analisis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarcaCarroEntityTallererEntity",
                columns: table => new
                {
                    marcasId = table.Column<Guid>(type: "uuid", nullable: false),
                    talleresId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaCarroEntityTallererEntity", x => new { x.marcasId, x.talleresId });
                    table.ForeignKey(
                        name: "FK_MarcaCarroEntityTallererEntity_Marca_carro_marcasId",
                        column: x => x.marcasId,
                        principalTable: "Marca_carro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcaCarroEntityTallererEntity_Taller_talleresId",
                        column: x => x.talleresId,
                        principalTable: "Taller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosTaller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    primer_nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    segundo_nombre = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    primer_apellido = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    segundo_apellido = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    direccion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    cargo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    estado = table.Column<int>(type: "integer", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    contraseña = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    tallerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosTaller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosTaller_Taller_tallerId",
                        column: x => x.tallerId,
                        principalTable: "Taller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cotizacion_taller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    cantidad_piezas_reparar = table.Column<int>(type: "integer", nullable: false),
                    costo_reparacion = table.Column<double>(type: "double precision", nullable: false),
                    fecha_culminacion = table.Column<DateTime>(type: "DATE", nullable: true),
                    fecha_inicio = table.Column<DateTime>(type: "DATE", nullable: true),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    usuario_tallerId = table.Column<Guid>(type: "uuid", nullable: false),
                    idAnalisis = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizacion_taller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cotizacion_taller_UsuariosTaller_usuario_tallerId",
                        column: x => x.usuario_tallerId,
                        principalTable: "UsuariosTaller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefono",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo_area = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    numero_telefono = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    usuario_tallerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefono", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefono_UsuariosTaller_usuario_tallerId",
                        column: x => x.usuario_tallerId,
                        principalTable: "UsuariosTaller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_taller_usuario_tallerId",
                table: "Cotizacion_taller",
                column: "usuario_tallerId");

            migrationBuilder.CreateIndex(
                name: "IX_MarcaCarroEntityTallererEntity_talleresId",
                table: "MarcaCarroEntityTallererEntity",
                column: "talleresId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_compra_analisisId",
                table: "Orden_compra",
                column: "analisisId");

            migrationBuilder.CreateIndex(
                name: "IX_Piezas_analisisId",
                table: "Piezas",
                column: "analisisId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefono_usuario_tallerId",
                table: "Telefono",
                column: "usuario_tallerId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosTaller_tallerId",
                table: "UsuariosTaller",
                column: "tallerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotizacion_taller");

            migrationBuilder.DropTable(
                name: "MarcaCarroEntityTallererEntity");

            migrationBuilder.DropTable(
                name: "Orden_compra");

            migrationBuilder.DropTable(
                name: "Piezas");

            migrationBuilder.DropTable(
                name: "Telefono");

            migrationBuilder.DropTable(
                name: "Marca_carro");

            migrationBuilder.DropTable(
                name: "Analisis");

            migrationBuilder.DropTable(
                name: "UsuariosTaller");

            migrationBuilder.DropTable(
                name: "Taller");
        }
    }
}
