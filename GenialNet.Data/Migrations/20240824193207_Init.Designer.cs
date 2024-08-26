﻿// <auto-generated />
using System;
using GenialNet.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GenialNet.Data.Migrations
{
    [DbContext(typeof(GenialNetContext))]
    [Migration("20240824193207_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GenialNet.Domain.Entities.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("GenialNet.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Medida")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("GenialNet.Domain.Entities.ProdutoFornecedor", b =>
                {
                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorDeCompra")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProdutoId", "FornecedorId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("ProdutoFornecedor");
                });

            modelBuilder.Entity("GenialNet.Domain.Entities.ProdutoFornecedor", b =>
                {
                    b.HasOne("GenialNet.Domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany("ProdutoFornecedores")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GenialNet.Domain.Entities.Produto", "Produto")
                        .WithMany("ProdutoFornecedores")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("GenialNet.Domain.Entities.Fornecedor", b =>
                {
                    b.Navigation("ProdutoFornecedores");
                });

            modelBuilder.Entity("GenialNet.Domain.Entities.Produto", b =>
                {
                    b.Navigation("ProdutoFornecedores");
                });
#pragma warning restore 612, 618
        }
    }
}
