using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ForLogic.AvaliacaoAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialAvaliacaoApiDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "avaliacao",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_referencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pontuacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categoria_nota",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_categoria = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    nota_minima = table.Column<int>(type: "int", nullable: false),
                    nota_maxima = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria_nota", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_cliente = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    nome_contato = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    cnpj = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    data_insercao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "avalicao_cliente",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    cliente_id = table.Column<long>(type: "bigint", nullable: false),
                    AvaliacaoId = table.Column<long>(type: "bigint", nullable: false),
                    avaliacao_id = table.Column<long>(type: "bigint", nullable: false),
                    CategoriaNotaId = table.Column<long>(type: "bigint", nullable: false),
                    categoria_nota_id = table.Column<long>(type: "bigint", nullable: false),
                    nota = table.Column<int>(type: "int", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_avaliacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avalicao_cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_avalicao_cliente_avaliacao_avaliacao_id",
                        column: x => x.avaliacao_id,
                        principalTable: "avaliacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_avalicao_cliente_categoria_nota_categoria_nota_id",
                        column: x => x.categoria_nota_id,
                        principalTable: "categoria_nota",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_avalicao_cliente_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "avaliacao",
                columns: new[] { "id", "data_referencia", "pontuacao" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2L, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "categoria_nota",
                columns: new[] { "id", "nome_categoria", "nota_maxima", "nota_minima" },
                values: new object[,]
                {
                    { 1L, "Detratores", 6, 0 },
                    { 2L, "Neutros", 8, 7 },
                    { 3L, "Promotores", 10, 9 }
                });

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "id", "cnpj", "data_insercao", "nome_cliente", "nome_contato" },
                values: new object[,]
                {
                    { 1L, "10.234.111/0001-01", new DateTime(2023, 5, 7, 23, 3, 10, 831, DateTimeKind.Local).AddTicks(6923), "Cliente A", "Cliente A Contato" },
                    { 2L, "10.334.111/0001-01", new DateTime(2023, 5, 7, 23, 3, 10, 831, DateTimeKind.Local).AddTicks(6948), "Cliente B", "Cliente B Contato" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_avalicao_cliente_avaliacao_id",
                table: "avalicao_cliente",
                column: "avaliacao_id");

            migrationBuilder.CreateIndex(
                name: "IX_avalicao_cliente_categoria_nota_id",
                table: "avalicao_cliente",
                column: "categoria_nota_id");

            migrationBuilder.CreateIndex(
                name: "IX_avalicao_cliente_cliente_id",
                table: "avalicao_cliente",
                column: "cliente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avalicao_cliente");

            migrationBuilder.DropTable(
                name: "avaliacao");

            migrationBuilder.DropTable(
                name: "categoria_nota");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
