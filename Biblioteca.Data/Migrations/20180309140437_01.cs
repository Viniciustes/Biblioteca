using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DtGeracao = table.Column<DateTime>(nullable: false),
                    Tarifa = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Checkout",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BibliotecaPatrimonioId = table.Column<Guid>(nullable: true),
                    CartaoId = table.Column<Guid>(nullable: true),
                    DtDevolucao = table.Column<DateTime>(nullable: false),
                    DtEmprestimo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkout", x => x.Id);
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
                    AcervoId = table.Column<Guid>(nullable: true),
                    CartaoId = table.Column<Guid>(nullable: true),
                    DtDevolucao = table.Column<DateTime>(nullable: true),
                    DtEmprestimo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistorico", x => x.Id);
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
                    CartaoBibliotecaId = table.Column<Guid>(nullable: true),
                    DtReserva = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_Cartao_CartaoBibliotecaId",
                        column: x => x.CartaoBibliotecaId,
                        principalTable: "Cartao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    CartaoId = table.Column<Guid>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    FilialResponsavelId = table.Column<Guid>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    TelefoneCelular = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Cartao_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CEP = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Logadouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filial",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DtAbertura = table.Column<DateTime>(nullable: false),
                    EnderecoId = table.Column<Guid>(nullable: true),
                    ImagemUrl = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filial_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
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
                    FilialId = table.Column<Guid>(nullable: true),
                    ImagemUrl = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorarioFuncionamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DiaDaSemana = table.Column<int>(nullable: false),
                    FilialId = table.Column<Guid>(nullable: true),
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
                name: "IX_Cliente_CartaoId",
                table: "Cliente",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_FilialResponsavelId",
                table: "Cliente",
                column: "FilialResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ClienteId",
                table: "Endereco",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Filial_EnderecoId",
                table: "Filial",
                column: "EnderecoId");

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
                name: "FK_Checkout_Acervo_BibliotecaPatrimonioId",
                table: "Checkout",
                column: "BibliotecaPatrimonioId",
                principalTable: "Acervo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistorico_Acervo_AcervoId",
                table: "CheckoutHistorico",
                column: "AcervoId",
                principalTable: "Acervo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Acervo_AcervoId",
                table: "Reserva",
                column: "AcervoId",
                principalTable: "Acervo",
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
                name: "Status");

            migrationBuilder.DropTable(
                name: "Filial");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Cartao");
        }
    }
}
