using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrinho.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoCompras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalCompra = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoCompras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    SetorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Setor_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoProduto",
                columns: table => new
                {
                    CarrinhoId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoProduto", x => new { x.CarrinhoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_CarrinhoProduto_Produto_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrinhoProduto_CarrinhoCompras_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "CarrinhoCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoProduto_ProdutoId",
                table: "CarrinhoProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_SetorId",
                table: "Produto",
                column: "SetorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoProduto");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "CarrinhoCompras");

            migrationBuilder.DropTable(
                name: "Setor");
        }
    }
}
