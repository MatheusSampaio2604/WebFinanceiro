﻿// <auto-generated />
using System;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231220143301_2")]
    partial class _2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Acoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Acoes");
                });

            modelBuilder.Entity("Domain.Models.Fii", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Fii");
                });

            modelBuilder.Entity("Domain.Models.Mensagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Ativo");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAlteracao");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCadastro");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Titulo");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("Mensagem");
                });

            modelBuilder.Entity("Domain.Models.Quantidades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AcaoId")
                        .HasColumnType("int")
                        .HasColumnName("AcaoId");

                    b.Property<int?>("FiiId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("FiiId");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AcaoId");

                    b.HasIndex("FiiId");

                    b.ToTable("Quantidade");
                });

            modelBuilder.Entity("Domain.Models.Valores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCompra");

                    b.Property<int>("QuantidadeId")
                        .HasColumnType("int")
                        .HasColumnName("QuatidadeId");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("QuantidadeId");

                    b.ToTable("Valores");
                });

            modelBuilder.Entity("Domain.Models.Quantidades", b =>
                {
                    b.HasOne("Domain.Models.Acoes", "Acoes")
                        .WithMany("Quantidades")
                        .HasForeignKey("AcaoId");

                    b.HasOne("Domain.Models.Fii", "Fii")
                        .WithMany("Quantidades")
                        .HasForeignKey("FiiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acoes");

                    b.Navigation("Fii");
                });

            modelBuilder.Entity("Domain.Models.Valores", b =>
                {
                    b.HasOne("Domain.Models.Quantidades", "Quantidades")
                        .WithMany("Valores")
                        .HasForeignKey("QuantidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quantidades");
                });

            modelBuilder.Entity("Domain.Models.Acoes", b =>
                {
                    b.Navigation("Quantidades");
                });

            modelBuilder.Entity("Domain.Models.Fii", b =>
                {
                    b.Navigation("Quantidades");
                });

            modelBuilder.Entity("Domain.Models.Quantidades", b =>
                {
                    b.Navigation("Valores");
                });
#pragma warning restore 612, 618
        }
    }
}
