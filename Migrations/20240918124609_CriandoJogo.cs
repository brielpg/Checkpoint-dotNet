using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkpoint1GabrielPescarolli.Migrations
{
    /// <inheritdoc />
    public partial class CriandoJogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CP_JOGOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Desenvolvedora = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Genero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Preco = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CP_JOGOS", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CP_JOGOS");
        }
    }
}
