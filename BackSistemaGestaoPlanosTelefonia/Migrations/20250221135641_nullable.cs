using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackSistemaGestaoPlanosTelefonia.Migrations
{
    /// <inheritdoc />
    public partial class nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientePlanos_PlanosDeSaude_PlanoId",
                table: "ClientePlanos");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlanoId",
                table: "ClientePlanos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                name: "FK_ClientePlanos_PlanosDeSaude_PlanoId",
                table: "ClientePlanos");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlanoId",
                table: "ClientePlanos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
