using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class Correcao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SolicitacaoCompra",
                keyColumn: "Id",
                keyValue: new Guid("4ebad170-61bf-46aa-a8dd-81e9afc5a76c"));

            migrationBuilder.AddColumn<int>(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitante",
                table: "SolicitacaoCompra");

            migrationBuilder.InsertData(
                table: "SolicitacaoCompra",
                columns: new[] { "Id", "Data", "Situacao" },
                values: new object[] { new Guid("4ebad170-61bf-46aa-a8dd-81e9afc5a76c"), new DateTime(2023, 9, 13, 13, 23, 1, 989, DateTimeKind.Local).AddTicks(7901), 1 });
        }
    }
}
