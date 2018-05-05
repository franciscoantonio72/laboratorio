using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Laboratorio.Data.Migrations
{
    public partial class _005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requisicao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ConvenioId = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    Desconto = table.Column<double>(nullable: false),
                    ExameId = table.Column<int>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false),
                    PostoColetaId = table.Column<Guid>(nullable: false),
                    SolicitanteId = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisicao_Convenio_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisicao_Exame_ExameId",
                        column: x => x.ExameId,
                        principalTable: "Exame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisicao_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisicao_PostoColeta_PostoColetaId",
                        column: x => x.PostoColetaId,
                        principalTable: "PostoColeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requisicao_Solicitante_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemRequisicao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    ExameId = table.Column<int>(nullable: false),
                    RequisicaoId = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRequisicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemRequisicao_Exame_ExameId",
                        column: x => x.ExameId,
                        principalTable: "Exame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemRequisicao_Requisicao_RequisicaoId",
                        column: x => x.RequisicaoId,
                        principalTable: "Requisicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequisicao_ExameId",
                table: "ItemRequisicao",
                column: "ExameId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequisicao_RequisicaoId",
                table: "ItemRequisicao",
                column: "RequisicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicao_ConvenioId",
                table: "Requisicao",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicao_ExameId",
                table: "Requisicao",
                column: "ExameId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicao_PacienteId",
                table: "Requisicao",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicao_PostoColetaId",
                table: "Requisicao",
                column: "PostoColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicao_SolicitanteId",
                table: "Requisicao",
                column: "SolicitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemRequisicao");

            migrationBuilder.DropTable(
                name: "Requisicao");
        }
    }
}
