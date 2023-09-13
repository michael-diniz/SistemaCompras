using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Infra.Data.Produto;
using SistemaCompra.Infra.Data.SolicitacaoCompra;
using System;

using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data
{
    public class SistemaCompraContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public SistemaCompraContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProdutoAgg.Produto> Produtos { get; set; }
        public DbSet<SolicitacaoCompraAgg.SolicitacaoCompra> SolicitacaoCompra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InsertProduto(modelBuilder);
            InsertSolicitacaoCompra(modelBuilder);

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitacaoCompraConfiguration());
        }

        private static void InsertSolicitacaoCompra(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SolicitacaoCompraAgg.SolicitacaoCompra>(sc =>
            {
                var solicitacaoCompraId = Guid.NewGuid();
                sc.HasData(new
                {
                    Id = solicitacaoCompraId,
                    Data = DateTime.Now,
                    Situacao = SolicitacaoCompraAgg.Situacao.Solicitado
                });

                sc.OwnsOne(x => x.UsuarioSolicitante).HasData(new
                {
                    SolicitacaoCompraId = solicitacaoCompraId,
                    Nome = "Rodrigo Ferreira"
                });
                sc.OwnsOne(x => x.NomeFornecedor).HasData(new
                {
                    SolicitacaoCompraId = solicitacaoCompraId,
                    Nome = "Triscal LTDA"
                });
                sc.OwnsOne(x => x.CondicaoPagamento).HasData(new
                {
                    SolicitacaoCompraId = solicitacaoCompraId,
                    Valor = 0
                });
                sc.OwnsOne(x => x.TotalGeral).HasData(new
                {
                    SolicitacaoCompraId = solicitacaoCompraId,
                    Value = 1000M
                });
            });
        }

        private static void InsertProduto(ModelBuilder modelBuilder)
        {
            var produtoId = Guid.NewGuid();

            modelBuilder.Entity<ProdutoAgg.Produto>(p =>
            {
                p.HasData(new
                {
                    Id = produtoId,
                    Nome = "Madeira - MDF1",
                    Descricao = "Descricao01",
                    Categoria = Categoria.Madeira,
                    Situacao = ProdutoAgg.Situacao.Ativo,
                });

                p.OwnsOne(x => x.Preco).HasData(new
                {
                    ProdutoId = produtoId,
                    Value = 100M
                });
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=sistemacompra;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        }
    }
}