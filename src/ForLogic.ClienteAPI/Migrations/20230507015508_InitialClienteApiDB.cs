using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ForLogic.ClienteAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialClienteApiDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "id", "cnpj", "data_insercao", "nome_cliente", "nome_contato" },
                values: new object[,]
                {
                    { 1L, "XX.XXX.XXX/0001-XX", new DateTime(2023, 5, 6, 22, 55, 8, 801, DateTimeKind.Local).AddTicks(9048), "Cliente A", "Cliente A Contato" },
                    { 2L, "XX.XXX.XXX/0001-XX", new DateTime(2023, 5, 6, 22, 55, 8, 801, DateTimeKind.Local).AddTicks(9073), "Cliente B", "Cliente B Contato" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
