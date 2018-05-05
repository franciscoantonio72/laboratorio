using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Laboratorio.Data.Migrations
{
    public partial class _004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convenio_PostoColeta_PostoColetaId",
                table: "Convenio");

            migrationBuilder.DropForeignKey(
                name: "FK_Exame_PostoColeta_PostoColetaId",
                table: "Exame");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_PostoColeta_PostoColetaId",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitante_PostoColeta_PostoColetaId",
                table: "Solicitante");

            migrationBuilder.DropIndex(
                name: "IX_Solicitante_PostoColetaId",
                table: "Solicitante");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_PostoColetaId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Exame_PostoColetaId",
                table: "Exame");

            migrationBuilder.DropIndex(
                name: "IX_Convenio_PostoColetaId",
                table: "Convenio");

            migrationBuilder.DropColumn(
                name: "PostoColetaId",
                table: "Solicitante");

            migrationBuilder.DropColumn(
                name: "PostoColetaId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "PostoColetaId",
                table: "Exame");

            migrationBuilder.DropColumn(
                name: "PostoColetaId",
                table: "Convenio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PostoColetaId",
                table: "Solicitante",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostoColetaId",
                table: "Paciente",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostoColetaId",
                table: "Exame",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostoColetaId",
                table: "Convenio",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Solicitante_PostoColetaId",
                table: "Solicitante",
                column: "PostoColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_PostoColetaId",
                table: "Paciente",
                column: "PostoColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_PostoColetaId",
                table: "Exame",
                column: "PostoColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Convenio_PostoColetaId",
                table: "Convenio",
                column: "PostoColetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Convenio_PostoColeta_PostoColetaId",
                table: "Convenio",
                column: "PostoColetaId",
                principalTable: "PostoColeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exame_PostoColeta_PostoColetaId",
                table: "Exame",
                column: "PostoColetaId",
                principalTable: "PostoColeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_PostoColeta_PostoColetaId",
                table: "Paciente",
                column: "PostoColetaId",
                principalTable: "PostoColeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitante_PostoColeta_PostoColetaId",
                table: "Solicitante",
                column: "PostoColetaId",
                principalTable: "PostoColeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
