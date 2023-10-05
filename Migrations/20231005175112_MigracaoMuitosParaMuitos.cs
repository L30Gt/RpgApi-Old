using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 100, 189, 95, 122, 90, 153, 216, 214, 93, 12, 3, 154, 141, 139, 63, 26, 138, 141, 218, 7, 6, 208, 90, 58, 0, 87, 105, 131, 63, 196, 11, 189, 27, 78, 94, 245, 109, 230, 103, 85, 172, 25, 196, 140, 5, 213, 93, 225, 69, 23, 39, 64, 104, 192, 37, 20, 164, 128, 57, 65, 151, 88, 31, 16 }, new byte[] { 140, 159, 42, 242, 17, 58, 4, 79, 0, 216, 107, 255, 217, 65, 190, 246, 136, 40, 196, 80, 233, 198, 254, 251, 98, 15, 62, 149, 36, 194, 189, 209, 91, 230, 193, 52, 215, 231, 222, 161, 130, 172, 213, 141, 147, 111, 135, 125, 38, 235, 241, 198, 90, 20, 226, 244, 45, 218, 101, 118, 147, 4, 146, 71, 220, 69, 164, 146, 36, 73, 253, 165, 178, 58, 89, 38, 25, 149, 196, 134, 82, 123, 25, 59, 189, 52, 70, 157, 130, 230, 15, 36, 13, 213, 66, 33, 182, 102, 232, 139, 18, 141, 135, 119, 57, 193, 59, 172, 100, 32, 193, 8, 183, 232, 137, 21, 0, 135, 208, 52, 85, 30, 135, 213, 54, 151, 6, 183 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 159, 114, 206, 166, 206, 223, 248, 208, 104, 88, 187, 131, 58, 171, 0, 112, 236, 156, 232, 81, 217, 243, 202, 72, 195, 12, 109, 140, 251, 229, 42, 147, 166, 177, 37, 99, 28, 104, 21, 95, 187, 137, 12, 244, 82, 217, 157, 113, 32, 19, 154, 221, 78, 91, 156, 236, 33, 114, 245, 215, 232, 217, 19, 240 }, new byte[] { 224, 194, 166, 39, 194, 71, 238, 154, 87, 246, 96, 197, 40, 37, 39, 123, 10, 91, 35, 82, 114, 120, 221, 220, 25, 182, 136, 155, 106, 102, 52, 122, 32, 94, 180, 45, 9, 120, 211, 201, 97, 251, 96, 238, 96, 19, 94, 170, 135, 205, 151, 31, 139, 131, 93, 49, 52, 184, 136, 144, 121, 221, 59, 232, 165, 172, 123, 38, 253, 182, 82, 51, 13, 94, 151, 40, 70, 128, 188, 44, 247, 203, 252, 56, 197, 104, 50, 120, 218, 79, 98, 85, 199, 69, 79, 191, 242, 156, 21, 90, 13, 38, 128, 179, 110, 20, 249, 47, 76, 246, 104, 152, 176, 219, 112, 15, 115, 36, 140, 54, 110, 104, 207, 217, 85, 72, 74, 158 } });
        }
    }
}
