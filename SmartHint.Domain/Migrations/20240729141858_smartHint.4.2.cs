using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHint.Domain.Migrations
{
    /// <inheritdoc />
    public partial class smartHint42 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Clientes",
                type: "varchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<bool>(
                name: "InscricaoEstadualPessoaFisica",
                table: "Clientes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InscricaoEstadualPessoaFisica",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Clientes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldMaxLength: 12);
        }
    }
}
