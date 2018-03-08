using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Migrations
{
    public partial class _02UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartaoId",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilialResponsavelId",
                table: "Cliente",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtGeracao = table.Column<DateTime>(nullable: false),
                    Tarifa = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    DtAbertura = table.Column<DateTime>(nullable: false),
                    EnderecoIdEndereco = table.Column<Guid>(nullable: false),
                    ImagemUrl = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    Telefone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filial_Endereco_EnderecoIdEndereco",
                        column: x => x.EnderecoIdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HorarioFuncionamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DiaDaSemana = table.Column<int>(nullable: false),
                    FilialId = table.Column<int>(nullable: true),
                    HoraDeAbertura = table.Column<int>(nullable: false),
                    HoraDeFechamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioFuncionamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioFuncionamento_Filial_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acervo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Custo = table.Column<decimal>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FilialId = table.Column<int>(nullable: true),
                    ImagemUrl = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: false),
                    Autor = table.Column<string>(nullable: true),
                    CodigoBarras = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    Diretor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acervo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acervo_Filial_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acervo_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkout",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BibliotecaPatrimonioId = table.Column<Guid>(nullable: false),
                    CartaoId = table.Column<int>(nullable: true),
                    DtDevolucao = table.Column<DateTime>(nullable: false),
                    DtEmprestimo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkout_Acervo_BibliotecaPatrimonioId",
                        column: x => x.BibliotecaPatrimonioId,
                        principalTable: "Acervo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checkout_Cartao_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutHistorico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AcervoId = table.Column<Guid>(nullable: false),
                    CartaoId = table.Column<int>(nullable: true),
                    DtDevolucao = table.Column<DateTime>(nullable: true),
                    DtEmprestimo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutHistorico_Acervo_AcervoId",
                        column: x => x.AcervoId,
                        principalTable: "Acervo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutHistorico_Cartao_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AcervoId = table.Column<Guid>(nullable: true),
                    CartaoBibliotecaId = table.Column<int>(nullable: true),
                    DtReserva = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_Acervo_AcervoId",
                        column: x => x.AcervoId,
                        principalTable: "Acervo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Cartao_CartaoBibliotecaId",
                        column: x => x.CartaoBibliotecaId,
                        principalTable: "Cartao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CartaoId",
                table: "Cliente",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_FilialResponsavelId",
                table: "Cliente",
                column: "FilialResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Acervo_FilialId",
                table: "Acervo",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_Acervo_StatusId",
                table: "Acervo",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkout_BibliotecaPatrimonioId",
                table: "Checkout",
                column: "BibliotecaPatrimonioId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkout_CartaoId",
                table: "Checkout",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistorico_AcervoId",
                table: "CheckoutHistorico",
                column: "AcervoId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistorico_CartaoId",
                table: "CheckoutHistorico",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Filial_EnderecoIdEndereco",
                table: "Filial",
                column: "EnderecoIdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioFuncionamento_FilialId",
                table: "HorarioFuncionamento",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_AcervoId",
                table: "Reserva",
                column: "AcervoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_CartaoBibliotecaId",
                table: "Reserva",
                column: "CartaoBibliotecaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Cartao_CartaoId",
                table: "Cliente",
                column: "CartaoId",
                principalTable: "Cartao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Filial_FilialResponsavelId",
                table: "Cliente",
                column: "FilialResponsavelId",
                principalTable: "Filial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Cartao_CartaoId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Filial_FilialResponsavelId",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "Checkout");

            migrationBuilder.DropTable(
                name: "CheckoutHistorico");

            migrationBuilder.DropTable(
                name: "HorarioFuncionamento");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Acervo");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "Filial");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_CartaoId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_FilialResponsavelId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "CartaoId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "FilialResponsavelId",
                table: "Cliente");
        }
    }
}
