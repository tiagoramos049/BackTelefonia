using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackSistemaGestaoPlanosTelefonia.Migrations
{
    /// <inheritdoc />
    public partial class retirar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientePlanos_Clientes_ClienteId",
                table: "ClientePlanos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientePlanos_PlanosDeSaude_PlanoId",
                table: "ClientePlanos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "PlanosDeSaude");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientePlanos_Clientes_ClienteId",
                table: "ClientePlanos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientePlanos_PlanosDeSaude_PlanoId",
                table: "ClientePlanos",
                column: "PlanoId",
                principalTable: "PlanosDeSaude",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientePlanos_Clientes_ClienteId",
                table: "ClientePlanos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientePlanos_PlanosDeSaude_PlanoId",
                table: "ClientePlanos");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "PlanosDeSaude",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientePlanos_Clientes_ClienteId",
                table: "ClientePlanos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientePlanos_PlanosDeSaude_PlanoId",
                table: "ClientePlanos",
                column: "PlanoId",
                principalTable: "PlanosDeSaude",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
