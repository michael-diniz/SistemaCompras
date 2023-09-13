using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.Produto;
using SistemaCompra.Infra.Data.SolicitacaoCompra;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data
{
    public class SistemaCompraContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public SistemaCompraContext(DbContextOptions options) : base(options) { }
        public DbSet<ProdutoAgg.Produto> Produtos { get; set; }
        public DbSet<SolicitacaoCompraAgg.SolicitacaoCompra> SolicitacaoCompra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoAgg.Produto>()
            .HasData(
                new ProdutoAgg.Produto("Produto01", "Descricao01", "Madeira", 100)
            );            

            modelBuilder.Entity<SolicitacaoCompraAgg.SolicitacaoCompra>()
            .HasData(
                new SolicitacaoCompraAgg.SolicitacaoCompra("Rodrigo", "Fornecedor01")
            );            

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitacaoCompraConfiguration());

            //modelBuilder.Entity<ProdutoAgg.Produto>();
            ////.HasData(
            ////    new ProdutoAgg.Produto("Produto01", "Descricao01", "Madeira", 100)
            ////);
            ////modelBuilder.Entity<ProdutoAgg.Produto>()
            ////    .Ignore(s => s.Preco);

            //modelBuilder.Entity<SolicitacaoCompraAgg.SolicitacaoCompra>();
            //    //.HasData(
            //    //    new SolicitacaoCompraAgg.SolicitacaoCompra("Rodrigo", "Fornecedor01")
            //    //);
            ////modelBuilder.Entity<SolicitacaoCompraAgg.SolicitacaoCompra>()
            ////    .Ignore(s => s.CondicaoPagamento);
            ////modelBuilder.Entity<SolicitacaoCompraAgg.SolicitacaoCompra>()
            ////    .Ignore(s => s.NomeFornecedor);
            ////modelBuilder.Entity<SolicitacaoCompraAgg.SolicitacaoCompra>()
            ////    .Ignore(s => s.UsuarioSolicitante);

            //modelBuilder.Ignore<Event>();

            //modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            //modelBuilder.ApplyConfiguration(new SolicitacaoCompraConfiguration());            
        }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)  
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SistemaCompras;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        }        
    }
}
