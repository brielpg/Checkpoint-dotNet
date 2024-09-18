using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkpoint1GabrielPescarolli.Migrations
{
    /// <inheritdoc />
    public partial class CriandoEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CP_ENDERECOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CEP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CP_ENDERECOS", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CP_ENDERECOS");
        }
    }
}
