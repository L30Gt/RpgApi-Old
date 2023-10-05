using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 159, 114, 206, 166, 206, 223, 248, 208, 104, 88, 187, 131, 58, 171, 0, 112, 236, 156, 232, 81, 217, 243, 202, 72, 195, 12, 109, 140, 251, 229, 42, 147, 166, 177, 37, 99, 28, 104, 21, 95, 187, 137, 12, 244, 82, 217, 157, 113, 32, 19, 154, 221, 78, 91, 156, 236, 33, 114, 245, 215, 232, 217, 19, 240 }, new byte[] { 224, 194, 166, 39, 194, 71, 238, 154, 87, 246, 96, 197, 40, 37, 39, 123, 10, 91, 35, 82, 114, 120, 221, 220, 25, 182, 136, 155, 106, 102, 52, 122, 32, 94, 180, 45, 9, 120, 211, 201, 97, 251, 96, 238, 96, 19, 94, 170, 135, 205, 151, 31, 139, 131, 93, 49, 52, 184, 136, 144, 121, 221, 59, 232, 165, 172, 123, 38, 253, 182, 82, 51, 13, 94, 151, 40, 70, 128, 188, 44, 247, 203, 252, 56, 197, 104, 50, 120, 218, 79, 98, 85, 199, 69, 79, 191, 242, 156, 21, 90, 13, 38, 128, 179, 110, 20, 249, 47, 76, 246, 104, 152, 176, 219, 112, 15, 115, 36, 140, 54, 110, 104, 207, 217, 85, 72, 74, 158 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 223, 204, 163, 45, 208, 38, 157, 80, 106, 30, 104, 157, 111, 111, 237, 151, 46, 39, 132, 185, 8, 73, 96, 18, 11, 35, 59, 166, 197, 126, 24, 17, 112, 57, 12, 229, 181, 183, 72, 234, 117, 229, 185, 55, 166, 155, 75, 254, 31, 183, 23, 14, 243, 227, 116, 76, 31, 78, 231, 167, 206, 35, 223, 215 }, new byte[] { 189, 170, 116, 251, 89, 126, 88, 188, 193, 60, 156, 231, 210, 139, 193, 5, 146, 158, 59, 115, 115, 27, 20, 185, 197, 184, 112, 24, 2, 163, 226, 194, 89, 31, 40, 119, 86, 96, 168, 185, 69, 91, 244, 120, 182, 76, 81, 130, 255, 238, 65, 150, 149, 229, 239, 94, 136, 172, 98, 230, 132, 200, 56, 76, 156, 37, 145, 210, 79, 163, 100, 149, 180, 116, 6, 149, 55, 74, 48, 165, 184, 176, 232, 80, 83, 116, 192, 252, 15, 245, 77, 89, 160, 236, 176, 132, 46, 253, 217, 32, 156, 63, 217, 149, 231, 231, 111, 131, 214, 95, 13, 198, 1, 44, 182, 129, 121, 74, 14, 66, 172, 110, 20, 153, 57, 171, 191, 207 } });
        }
    }
}
