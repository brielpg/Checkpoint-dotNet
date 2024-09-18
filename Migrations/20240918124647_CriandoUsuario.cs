using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkpoint1GabrielPescarolli.Migrations
{
    /// <inheritdoc />
    public partial class CriandoUsuario : Migration
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
                name: "CP_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CP_USUARIOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CP_USUARIOS_CP_ENDERECOS_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "CP_ENDERECOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CP_USUARIOS_EnderecoId",
                table: "CP_USUARIOS",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CP_USUARIOS");

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
