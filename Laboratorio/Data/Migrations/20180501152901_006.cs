using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Laboratorio.Data.Migrations
{
    public partial class _006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRequisicao_Exame_ExameId",
                table: "ItemRequisicao");

            migrationBuilder.DropIndex(
                name: "IX_ItemRequisicao_ExameId",
                table: "ItemRequisicao");

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Exame",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Exame");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequisicao_ExameId",
                table: "ItemRequisicao",
                column: "ExameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRequisicao_Exame_ExameId",
                table: "ItemRequisicao",
                column: "ExameId",
                principalTable: "Exame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
