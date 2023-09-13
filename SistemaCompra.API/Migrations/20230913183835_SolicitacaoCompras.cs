using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class SolicitacaoCompras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("1645db2a-2b0c-49cf-8c5c-1241081902ae"));

            migrationBuilder.DeleteData(
                table: "SolicitacaoCompra",
                keyColumn: "Id",
                keyValue: new Guid("73dd4878-cb93-4554-a67b-a1f6a99603d7"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Situacao", "Preco" },
                values: new object[] { new Guid("86db7c75-f1f5-40ad-8bac-3aae631d50d5"), 1, "Descricao01", "Madeira - MDF1", 1, 100m });

            migrationBuilder.InsertData(
                table: "SolicitacaoCompra",
                columns: new[] { "Id", "Data", "Situacao", "TotalGeral", "CondicaoPagamento", "NomeFornecedor", "UsuarioSolicitante" },
                values: new object[] { new Guid("6c8a1bc5-4c58-431f-9375-fa5b79175d20"), new DateTime(2023, 9, 13, 19, 38, 34, 584, DateTimeKind.Local).AddTicks(8641), 1, 1000m, 0, "Triscal LTDA", "Rodrigo Ferreira" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("86db7c75-f1f5-40ad-8bac-3aae631d50d5"));

            migrationBuilder.DeleteData(
                table: "SolicitacaoCompra",
                keyColumn: "Id",
                keyValue: new Guid("6c8a1bc5-4c58-431f-9375-fa5b79175d20"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Situacao", "Preco" },
                values: new object[] { new Guid("1645db2a-2b0c-49cf-8c5c-1241081902ae"), 1, "Descricao01", "Madeira - MDF1", 1, 100m });

            migrationBuilder.InsertData(
                table: "SolicitacaoCompra",
                columns: new[] { "Id", "Data", "Situacao", "TotalGeral", "CondicaoPagamento", "NomeFornecedor", "UsuarioSolicitante" },
                values: new object[] { new Guid("73dd4878-cb93-4554-a67b-a1f6a99603d7"), new DateTime(2023, 9, 13, 19, 23, 26, 344, DateTimeKind.Local).AddTicks(5582), 1, 1000m, 0, "Triscal LTDA", "Rodrigo Ferreira" });
        }
    }
}
