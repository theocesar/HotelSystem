using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelEntity.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Frigobar",
                columns: table => new
                {
                    CodigoItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frigobar", x => x.CodigoItem);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    TipoFuncionario = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.IdFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "Lavanderia",
                columns: table => new
                {
                    CodigoLavanderia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lavanderia", x => x.CodigoLavanderia);
                });

            migrationBuilder.CreateTable(
                name: "Quartos",
                columns: table => new
                {
                    CodQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    CapacidadeMaxima = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    TipoQuarto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Adaptado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartos", x => x.CodQuarto);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    CodigoProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.CodigoProduto);
                });

            migrationBuilder.CreateTable(
                name: "Filial",
                columns: table => new
                {
                    CodFilial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CodQuarto = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Adaptado = table.Column<bool>(type: "bit", nullable: false),
                    QuantidadeEstrelas = table.Column<int>(type: "int", nullable: false),
                    QuartoCodQuarto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filial", x => x.CodFilial);
                    table.ForeignKey(
                        name: "FK_Filial_Quartos_QuartoCodQuarto",
                        column: x => x.QuartoCodQuarto,
                        principalTable: "Quartos",
                        principalColumn: "CodQuarto");
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    CodReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DTEntrada = table.Column<DateOnly>(type: "date", nullable: false),
                    DTSaida = table.Column<DateOnly>(type: "date", nullable: false),
                    CapacidadeOpcional = table.Column<bool>(type: "bit", nullable: false),
                    DTCancelamento = table.Column<DateOnly>(type: "date", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    CodQuarto = table.Column<int>(type: "int", nullable: false),
                    FuncionarioIdFuncionario = table.Column<int>(type: "int", nullable: true),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: true),
                    QuartoCodQuarto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.CodReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Reserva_Funcionario_FuncionarioIdFuncionario",
                        column: x => x.FuncionarioIdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario");
                    table.ForeignKey(
                        name: "FK_Reserva_Quartos_QuartoCodQuarto",
                        column: x => x.QuartoCodQuarto,
                        principalTable: "Quartos",
                        principalColumn: "CodQuarto");
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    CodNota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPagamento = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CodReserva = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", maxLength: 100, nullable: false),
                    ReservaCodReserva = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscal", x => x.CodNota);
                    table.ForeignKey(
                        name: "FK_NotaFiscal_Reserva_ReservaCodReserva",
                        column: x => x.ReservaCodReserva,
                        principalTable: "Reserva",
                        principalColumn: "CodReserva");
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    CodProduto = table.Column<int>(type: "int", nullable: false),
                    CodReserva = table.Column<int>(type: "int", nullable: false),
                    DataPedido = table.Column<DateOnly>(type: "date", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    EntregueQuarto = table.Column<bool>(type: "bit", nullable: false),
                    RestauranteCodigoProduto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => new { x.CodProduto, x.CodReserva, x.DataPedido });
                    table.ForeignKey(
                        name: "FK_Pedido_Reserva_CodReserva",
                        column: x => x.CodReserva,
                        principalTable: "Reserva",
                        principalColumn: "CodReserva",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Restaurante_RestauranteCodigoProduto",
                        column: x => x.RestauranteCodigoProduto,
                        principalTable: "Restaurante",
                        principalColumn: "CodigoProduto");
                });

            migrationBuilder.CreateTable(
                name: "ServicoFrigobar",
                columns: table => new
                {
                    CodItem = table.Column<int>(type: "int", nullable: false),
                    CodReserva = table.Column<int>(type: "int", nullable: false),
                    DataSolicitacao = table.Column<DateOnly>(type: "date", nullable: false),
                    FrigobarCodigoItem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoFrigobar", x => new { x.CodItem, x.CodReserva, x.DataSolicitacao });
                    table.ForeignKey(
                        name: "FK_ServicoFrigobar_Frigobar_FrigobarCodigoItem",
                        column: x => x.FrigobarCodigoItem,
                        principalTable: "Frigobar",
                        principalColumn: "CodigoItem");
                    table.ForeignKey(
                        name: "FK_ServicoFrigobar_Reserva_CodReserva",
                        column: x => x.CodReserva,
                        principalTable: "Reserva",
                        principalColumn: "CodReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicoLavanderia",
                columns: table => new
                {
                    CodLavanderia = table.Column<int>(type: "int", nullable: false),
                    CodReserva = table.Column<int>(type: "int", nullable: false),
                    DataPrestacao = table.Column<DateOnly>(type: "date", nullable: false),
                    LavanderiaCodigoLavanderia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoLavanderia", x => new { x.CodLavanderia, x.CodReserva, x.DataPrestacao });
                    table.ForeignKey(
                        name: "FK_ServicoLavanderia_Lavanderia_LavanderiaCodigoLavanderia",
                        column: x => x.LavanderiaCodigoLavanderia,
                        principalTable: "Lavanderia",
                        principalColumn: "CodigoLavanderia");
                    table.ForeignKey(
                        name: "FK_ServicoLavanderia_Reserva_CodReserva",
                        column: x => x.CodReserva,
                        principalTable: "Reserva",
                        principalColumn: "CodReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filial_QuartoCodQuarto",
                table: "Filial",
                column: "QuartoCodQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_ReservaCodReserva",
                table: "NotaFiscal",
                column: "ReservaCodReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CodReserva",
                table: "Pedido",
                column: "CodReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_RestauranteCodigoProduto",
                table: "Pedido",
                column: "RestauranteCodigoProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteIdCliente",
                table: "Reserva",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_FuncionarioIdFuncionario",
                table: "Reserva",
                column: "FuncionarioIdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_QuartoCodQuarto",
                table: "Reserva",
                column: "QuartoCodQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoFrigobar_CodReserva",
                table: "ServicoFrigobar",
                column: "CodReserva");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoFrigobar_FrigobarCodigoItem",
                table: "ServicoFrigobar",
                column: "FrigobarCodigoItem");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoLavanderia_CodReserva",
                table: "ServicoLavanderia",
                column: "CodReserva");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoLavanderia_LavanderiaCodigoLavanderia",
                table: "ServicoLavanderia",
                column: "LavanderiaCodigoLavanderia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filial");

            migrationBuilder.DropTable(
                name: "NotaFiscal");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "ServicoFrigobar");

            migrationBuilder.DropTable(
                name: "ServicoLavanderia");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "Frigobar");

            migrationBuilder.DropTable(
                name: "Lavanderia");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Quartos");
        }
    }
}
