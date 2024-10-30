using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkpoint1GabrielPescarolli.Migrations
{
    /// <inheritdoc />
    public partial class CriandoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "CP_JOGOS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.CreateTable(
                name: "CP_PEDIDOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    JogoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CP_PEDIDOS", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CP_PEDIDOS");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "CP_JOGOS",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");
        }
    }
}
