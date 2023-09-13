using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoCompraAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCompraAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");

            //builder.Property(sc => sc.TotalGeral)
            //    .HasColumnName("TotalGeral")
            //    .HasColumnType("DECIMAL(18,2)");

            builder.OwnsOne(c => c.CondicaoPagamento, b => b.Property("Valor").HasColumnName("CondicaoPagamento"));
            builder.OwnsOne(c => c.NomeFornecedor, b => b.Property("Nome").HasColumnName("NomeFornecedor"));
            builder.OwnsOne(c => c.UsuarioSolicitante, b => b.Property("Nome").HasColumnName("UsuarioSolicitante"));
            builder.OwnsOne(c => c.TotalGeral, b => b.Property("Value").HasColumnName("TotalGeral"));

            //builder.Property(c => c.NomeFornecedor)
            //    .HasColumnName("NomeFornecedor")
            //    .HasColumnType("NVARCHAR")
            //    .HasMaxLength(30);

            //builder.Property(c => c.UsuarioSolicitante)
            //    .HasColumnName("UsuarioSolicitante")
            //    .HasColumnType("NVARCHAR")
            //    .HasMaxLength(30);
        }
    }
}