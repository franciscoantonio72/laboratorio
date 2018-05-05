using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Laboratorio.Data.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "PostoColeta",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Convenio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    PostoColetaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Convenio_PostoColeta_PostoColetaId",
                        column: x => x.PostoColetaId,
                        principalTable: "PostoColeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Codigo = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    PostoColetaId = table.Column<Guid>(nullable: false),
                    Sinonimo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exame_PostoColeta_PostoColetaId",
                        column: x => x.PostoColetaId,
                        principalTable: "PostoColeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Bairro = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    PostoColetaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_PostoColeta_PostoColetaId",
                        column: x => x.PostoColetaId,
                        principalTable: "PostoColeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CRM = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    PostoColetaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitante_PostoColeta_PostoColetaId",
                        column: x => x.PostoColetaId,
                        principalTable: "PostoColeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TabelaPreco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ConvenioId = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    PostoColetaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaPreco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabelaPreco_Convenio_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TabelaPreco_PostoColeta_PostoColetaId",
                        column: x => x.PostoColetaId,
                        principalTable: "PostoColeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensTabelaPreco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    ExameId = table.Column<int>(nullable: false),
                    Ponto = table.Column<double>(nullable: false),
                    PostoColetaId = table.Column<Guid>(nullable: false),
                    TabelaPrecoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensTabelaPreco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensTabelaPreco_Exame_ExameId",
                        column: x => x.ExameId,
                        principalTable: "Exame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensTabelaPreco_PostoColeta_PostoColetaId",
                        column: x => x.PostoColetaId,
                        principalTable: "PostoColeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensTabelaPreco_TabelaPreco_TabelaPrecoId",
                        column: x => x.TabelaPrecoId,
                        principalTable: "TabelaPreco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Convenio_PostoColetaId",
                table: "Convenio",
                column: "PostoColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_PostoColetaId",
                table: "Exame",
                column: "PostoColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensTabelaPreco_ExameId",
                table: "ItensTabelaPreco",
                column: "ExameId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensTabelaPreco_PostoColetaId",
                table: "ItensTabelaPreco",
                column: "PostoColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensTabelaPreco_TabelaPrecoId",
                table: "ItensTabelaPreco",
                column: "TabelaPrecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_PostoColetaId",
                table: "Paciente",
                column: "PostoColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitante_PostoColetaId",
                table: "Solicitante",
                column: "PostoColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaPreco_ConvenioId",
                table: "TabelaPreco",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaPreco_PostoColetaId",
                table: "TabelaPreco",
                column: "PostoColetaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensTabelaPreco");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Solicitante");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "TabelaPreco");

            migrationBuilder.DropTable(
                name: "Convenio");

            migrationBuilder.DropColumn(
                name: "Local",
                table: "PostoColeta");
        }
    }
}
