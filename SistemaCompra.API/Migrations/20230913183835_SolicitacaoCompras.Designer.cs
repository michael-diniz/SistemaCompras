﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaCompra.Infra.Data;

namespace SistemaCompra.API.Migrations
{
    [DbContext(typeof(SistemaCompraContext))]
    [Migration("20230913183835_SolicitacaoCompras")]
    partial class SolicitacaoCompras
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaCompra.Domain.ProdutoAggregate.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            Id = new Guid("86db7c75-f1f5-40ad-8bac-3aae631d50d5"),
                            Categoria = 1,
                            Descricao = "Descricao01",
                            Nome = "Madeira - MDF1",
                            Situacao = 1
                        });
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Qtde")
                        .HasColumnType("int");

                    b.Property<Guid?>("SolicitacaoCompraId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("SolicitacaoCompraId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SolicitacaoCompra");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6c8a1bc5-4c58-431f-9375-fa5b79175d20"),
                            Data = new DateTime(2023, 9, 13, 19, 38, 34, 584, DateTimeKind.Local).AddTicks(8641),
                            Situacao = 1
                        });
                });

            modelBuilder.Entity("SistemaCompra.Domain.ProdutoAggregate.Produto", b =>
                {
                    b.OwnsOne("SistemaCompra.Domain.Core.Model.Money", "Preco", b1 =>
                        {
                            b1.Property<Guid>("ProdutoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnName("Preco")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("ProdutoId");

                            b1.ToTable("Produto");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoId");

                            b1.HasData(
                                new
                                {
                                    ProdutoId = new Guid("86db7c75-f1f5-40ad-8bac-3aae631d50d5"),
                                    Value = 100m
                                });
                        });
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.Item", b =>
                {
                    b.HasOne("SistemaCompra.Domain.ProdutoAggregate.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.HasOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra", null)
                        .WithMany("Itens")
                        .HasForeignKey("SolicitacaoCompraId");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra", b =>
                {
                    b.OwnsOne("SistemaCompra.Domain.Core.Model.Money", "TotalGeral", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnName("TotalGeral")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");

                            b1.HasData(
                                new
                                {
                                    SolicitacaoCompraId = new Guid("6c8a1bc5-4c58-431f-9375-fa5b79175d20"),
                                    Value = 1000m
                                });
                        });

                    b.OwnsOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.CondicaoPagamento", "CondicaoPagamento", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Valor")
                                .HasColumnName("CondicaoPagamento")
                                .HasColumnType("int");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");

                            b1.HasData(
                                new
                                {
                                    SolicitacaoCompraId = new Guid("6c8a1bc5-4c58-431f-9375-fa5b79175d20"),
                                    Valor = 0
                                });
                        });

                    b.OwnsOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.NomeFornecedor", "NomeFornecedor", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Nome")
                                .HasColumnName("NomeFornecedor")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");

                            b1.HasData(
                                new
                                {
                                    SolicitacaoCompraId = new Guid("6c8a1bc5-4c58-431f-9375-fa5b79175d20"),
                                    Nome = "Triscal LTDA"
                                });
                        });

                    b.OwnsOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.UsuarioSolicitante", "UsuarioSolicitante", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Nome")
                                .HasColumnName("UsuarioSolicitante")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SolicitacaoCompraId");

                            b1.ToTable("SolicitacaoCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoCompraId");

                            b1.HasData(
                                new
                                {
                                    SolicitacaoCompraId = new Guid("6c8a1bc5-4c58-431f-9375-fa5b79175d20"),
                                    Nome = "Rodrigo Ferreira"
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}