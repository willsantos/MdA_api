﻿// <auto-generated />
using System;
using Mda.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mda.Repository.Migrations
{
    [DbContext(typeof(MdaContext))]
    [Migration("20230329180204_MigrationCorrecaoTarefa")]
    partial class MigrationCorrecaoTarefa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Mda.Domain.Entities.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDelecao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeArea")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("NotaFim")
                        .HasColumnType("int");

                    b.Property<int>("NotaInicio")
                        .HasColumnType("int");

                    b.Property<Guid>("RodaId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RodaId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Codigo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CodigoResgate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("GeradoEm")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Codigos");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Objetivo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AreaId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Bloqueios")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDelecao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Recursos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Objetivos");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Projeto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataAlvo")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDelecao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ObjetivoId")
                        .HasColumnType("char(36)");

                    b.Property<float>("Progresso")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ObjetivoId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Roda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Ano")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDelecao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Rodas");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Tarefa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDelecao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ProjetoId")
                        .HasColumnType("char(36)");

                    b.Property<int>("StatusTarefa")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataDelecao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Area", b =>
                {
                    b.HasOne("Mda.Domain.Entities.Roda", "Roda")
                        .WithMany("Areas")
                        .HasForeignKey("RodaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Roda");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Objetivo", b =>
                {
                    b.HasOne("Mda.Domain.Entities.Area", "Area")
                        .WithMany("Objetivos")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Projeto", b =>
                {
                    b.HasOne("Mda.Domain.Entities.Objetivo", "Objetivo")
                        .WithMany("Projetos")
                        .HasForeignKey("ObjetivoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Objetivo");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Roda", b =>
                {
                    b.HasOne("Mda.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Rodas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Tarefa", b =>
                {
                    b.HasOne("Mda.Domain.Entities.Projeto", "Projeto")
                        .WithMany("Tarefas")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Area", b =>
                {
                    b.Navigation("Objetivos");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Objetivo", b =>
                {
                    b.Navigation("Projetos");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Projeto", b =>
                {
                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Roda", b =>
                {
                    b.Navigation("Areas");
                });

            modelBuilder.Entity("Mda.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Rodas");
                });
#pragma warning restore 612, 618
        }
    }
}
