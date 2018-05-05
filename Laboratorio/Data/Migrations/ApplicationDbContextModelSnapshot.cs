﻿// <auto-generated />
using Laboratorio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Laboratorio.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Laboratorio.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Laboratorio.Models.Convenio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Convenio");
                });

            modelBuilder.Entity("Laboratorio.Models.Exame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao");

                    b.Property<double>("Preco");

                    b.Property<string>("Sinonimo");

                    b.HasKey("Id");

                    b.ToTable("Exame");
                });

            modelBuilder.Entity("Laboratorio.Models.ItemRequisicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<int>("ExameId");

                    b.Property<int>("RequisicaoId");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("RequisicaoId");

                    b.ToTable("ItemRequisicao");
                });

            modelBuilder.Entity("Laboratorio.Models.ItemRequisicaoTemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<int>("ExameId");

                    b.Property<Guid>("IdTemporario");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.ToTable("ItemRequisicaoTemp");
                });

            modelBuilder.Entity("Laboratorio.Models.ItemTabelaPreco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<int>("ExameId");

                    b.Property<double>("Ponto");

                    b.Property<Guid>("PostoColetaId");

                    b.Property<int>("TabelaPrecoId");

                    b.HasKey("Id");

                    b.HasIndex("ExameId");

                    b.HasIndex("PostoColetaId");

                    b.HasIndex("TabelaPrecoId");

                    b.ToTable("ItensTabelaPreco");
                });

            modelBuilder.Entity("Laboratorio.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("CPF");

                    b.Property<string>("Cidade");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Endereco");

                    b.Property<string>("Estado");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Laboratorio.Models.PostoColeta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Local");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("PostoColeta");
                });

            modelBuilder.Entity("Laboratorio.Models.Requisicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConvenioId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataEntrega");

                    b.Property<double>("Desconto");

                    b.Property<int>("ExameId");

                    b.Property<int>("PacienteId");

                    b.Property<Guid>("PostoColetaId");

                    b.Property<int>("SolicitanteId");

                    b.Property<double>("Total");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ConvenioId");

                    b.HasIndex("ExameId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("PostoColetaId");

                    b.HasIndex("SolicitanteId");

                    b.ToTable("Requisicao");
                });

            modelBuilder.Entity("Laboratorio.Models.Solicitante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CRM");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Solicitante");
                });

            modelBuilder.Entity("Laboratorio.Models.TabelaPreco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConvenioId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Nome");

                    b.Property<Guid>("PostoColetaId");

                    b.HasKey("Id");

                    b.HasIndex("ConvenioId");

                    b.HasIndex("PostoColetaId");

                    b.ToTable("TabelaPreco");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Laboratorio.Models.ItemRequisicao", b =>
                {
                    b.HasOne("Laboratorio.Models.Requisicao", "Requisicao")
                        .WithMany("ItensRequisicao")
                        .HasForeignKey("RequisicaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Laboratorio.Models.ItemTabelaPreco", b =>
                {
                    b.HasOne("Laboratorio.Models.Exame", "Exame")
                        .WithMany()
                        .HasForeignKey("ExameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Laboratorio.Models.PostoColeta", "PostoColeta")
                        .WithMany()
                        .HasForeignKey("PostoColetaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Laboratorio.Models.TabelaPreco", "TabelaPreco")
                        .WithMany("ItensTabelaPreco")
                        .HasForeignKey("TabelaPrecoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Laboratorio.Models.Requisicao", b =>
                {
                    b.HasOne("Laboratorio.Models.Convenio", "Convenio")
                        .WithMany()
                        .HasForeignKey("ConvenioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Laboratorio.Models.Exame", "Exame")
                        .WithMany()
                        .HasForeignKey("ExameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Laboratorio.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Laboratorio.Models.PostoColeta", "PostoColeta")
                        .WithMany()
                        .HasForeignKey("PostoColetaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Laboratorio.Models.Solicitante", "Solicitante")
                        .WithMany()
                        .HasForeignKey("SolicitanteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Laboratorio.Models.TabelaPreco", b =>
                {
                    b.HasOne("Laboratorio.Models.Convenio", "Convenio")
                        .WithMany()
                        .HasForeignKey("ConvenioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Laboratorio.Models.PostoColeta", "PostoColeta")
                        .WithMany()
                        .HasForeignKey("PostoColetaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Laboratorio.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Laboratorio.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Laboratorio.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Laboratorio.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
