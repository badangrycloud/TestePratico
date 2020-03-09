using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestePratico.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaCorrente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Agencia = table.Column<string>(maxLength: 4, nullable: false),
                    NumeroConta = table.Column<string>(maxLength: 15, nullable: false),
                    Digito = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lancamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContaCorrenteId = table.Column<Guid>(nullable: false),
                    TipoOperacao = table.Column<string>(nullable: false),
                    DataOperacao = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamento_ContaCorrente_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContaCorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_ContaCorrenteId",
                table: "Lancamento",
                column: "ContaCorrenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamento");

            migrationBuilder.DropTable(
                name: "ContaCorrente");
        }
    }
}
