using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaMigracaoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quantidade_Fii_FiiId",
                table: "Quantidade");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Valores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "FiiId",
                table: "Quantidade",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Quantidade_Fii_FiiId",
                table: "Quantidade",
                column: "FiiId",
                principalTable: "Fii",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quantidade_Fii_FiiId",
                table: "Quantidade");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Valores");

            migrationBuilder.AlterColumn<int>(
                name: "FiiId",
                table: "Quantidade",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quantidade_Fii_FiiId",
                table: "Quantidade",
                column: "FiiId",
                principalTable: "Fii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
